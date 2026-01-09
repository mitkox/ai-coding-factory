#!/usr/bin/env python3
import argparse
import datetime
import os
import pathlib
import re
import subprocess
import sys
from typing import Dict, List, Optional, Tuple
from xml.etree import ElementTree

STORY_ID_RE = re.compile(r"\bACF-\d+\b")


def read_text(path: pathlib.Path) -> str:
    return path.read_text(encoding="utf-8", errors="ignore")


def extract_front_matter(content: str) -> dict:
    lines = content.splitlines()
    if not lines or lines[0].strip() != "---":
        return {}
    data = {}
    for line in lines[1:]:
        if line.strip() == "---":
            break
        if ":" in line:
            key, value = line.split(":", 1)
            data[key.strip()] = value.strip()
    return data


def extract_story_id(content: str) -> Optional[str]:
    front = extract_front_matter(content)
    if "id" in front and STORY_ID_RE.fullmatch(front["id"]):
        return front["id"]

    for line in content.splitlines():
        match = re.match(r"^#+\s*(ACF-\d+)\b", line.strip())
        if match:
            return match.group(1)

    match = STORY_ID_RE.search(content)
    return match.group(0) if match else None


def extract_story_title(content: str, story_id: str) -> str:
    front = extract_front_matter(content)
    if "title" in front:
        return front["title"]

    for line in content.splitlines():
        if story_id in line:
            return line.replace("#", "").strip().replace(story_id, "").strip(" -:")
    return ""


def discover_story_files(stories_dir: pathlib.Path):
    stories = {}
    errors = []
    if not stories_dir.exists():
        errors.append(f"Stories directory not found: {stories_dir}")
        return stories, errors

    for path in sorted(stories_dir.rglob("*.md")):
        content = read_text(path)
        story_id = extract_story_id(content)
        if not story_id:
            errors.append(f"Missing story ID in {path}")
            continue
        if story_id in stories:
            errors.append(f"Duplicate story ID {story_id} in {path}")
            continue
        title = extract_story_title(content, story_id)
        stories[story_id] = {"path": path, "title": title}

    return stories, errors


def discover_tests(test_roots: List[pathlib.Path]):
    tests = {}
    for root in test_roots:
        if not root.exists():
            continue
        for path in root.rglob("*.cs"):
            if "Test" not in path.name and "Tests" not in path.name and "tests" not in str(path.parent).lower():
                continue
            content = read_text(path)
            for match in STORY_ID_RE.findall(content):
                tests.setdefault(match, set()).add(path)
    return tests


def default_commit_range() -> str:
    result = subprocess.run(
        ["git", "rev-list", "--count", "HEAD"],
        capture_output=True,
        text=True,
        check=False,
    )
    if result.returncode != 0:
        return "HEAD"
    try:
        count = int(result.stdout.strip())
    except ValueError:
        return "HEAD"
    if count <= 1:
        return "HEAD"
    window = min(20, count - 1)
    return f"HEAD~{window}..HEAD"


def collect_commits(commit_range: str) -> List[Tuple[str, str]]:
    result = subprocess.run(
        ["git", "log", commit_range, "--pretty=%H::%s"],
        capture_output=True,
        text=True,
        check=False,
    )
    if result.returncode != 0:
        raise RuntimeError("git log failed. Ensure git is available and commit range is valid.")

    commits = []
    for line in result.stdout.splitlines():
        if "::" in line:
            sha, subject = line.split("::", 1)
            commits.append((sha, subject))
    return commits


def map_commits_to_stories(commits: List[Tuple[str, str]]):
    mapping = {}
    for sha, subject in commits:
        for story_id in STORY_ID_RE.findall(subject):
            mapping.setdefault(story_id, []).append({"sha": sha, "subject": subject})
    return mapping


def parse_coverage_summary(path: pathlib.Path) -> Optional[Tuple[float, float]]:
    if not path.exists():
        return None
    try:
        tree = ElementTree.parse(path)
    except ElementTree.ParseError:
        return None
    root = tree.getroot()
    line_rate = float(root.attrib.get("line-rate", "0"))
    branch_rate = float(root.attrib.get("branch-rate", "0"))
    return line_rate, branch_rate


def utc_today() -> str:
    return datetime.datetime.now(datetime.timezone.utc).strftime("%Y-%m-%d")


def write_report(output: pathlib.Path, stories, tests, commit_map) -> None:
    output.parent.mkdir(parents=True, exist_ok=True)
    now = utc_today()
    lines = [
        "# Traceability Report",
        "",
        f"Generated: {now}",
        "",
        "| Story ID | Story Title | Tests | Commits |",
        "| --- | --- | --- | --- |",
    ]

    for story_id, info in sorted(stories.items()):
        test_list = sorted({p.name for p in tests.get(story_id, [])})
        commit_list = [c["subject"] for c in commit_map.get(story_id, [])]
        lines.append(
            f"| {story_id} | {info['title']} | {', '.join(test_list) or '-'} | {', '.join(commit_list) or '-'} |"
        )

    output.write_text("\n".join(lines) + "\n", encoding="utf-8")


def write_release_notes(output: pathlib.Path, stories, tests, commit_map, coverage: Optional[Tuple[float, float]]) -> None:
    output.parent.mkdir(parents=True, exist_ok=True)
    now = utc_today()
    lines = [
        "# Release Notes",
        "",
        f"Date: {now}",
        "",
        "## Delivered Stories",
        "",
    ]

    for story_id, info in sorted(stories.items()):
        lines.append(f"- {story_id}: {info['title']}")

    lines.extend(["", "## Linked Tests", ""])
    for story_id in sorted(stories.keys()):
        test_list = sorted({p.name for p in tests.get(story_id, [])})
        lines.append(f"- {story_id}: {', '.join(test_list) or '-'}")

    lines.extend(["", "## Coverage Summary", ""])
    if coverage:
        line_rate, branch_rate = coverage
        lines.append(f"- Line coverage: {line_rate * 100:.2f}%")
        lines.append(f"- Branch coverage: {branch_rate * 100:.2f}%")
    else:
        lines.append("- Coverage data not available")

    lines.extend(["", "## Known Risks / Deviations", "", "- None", ""])
    output.write_text("\n".join(lines), encoding="utf-8")


def main() -> int:
    parser = argparse.ArgumentParser(description="Traceability enforcement and reporting")
    subparsers = parser.add_subparsers(dest="command", required=True)

    def add_common_flags(p):
        p.add_argument("--stories-dir", default="artifacts/stories", help="Directory containing story files")
        p.add_argument("--tests-root", action="append", default=[], help="Test root(s) to scan")
        p.add_argument("--commit-range", default="", help="Git commit range (e.g., origin/main..HEAD)")
        p.add_argument("--skip-commits", action="store_true", help="Skip commit traceability check")

    validate_parser = subparsers.add_parser("validate", help="Validate traceability rules")
    add_common_flags(validate_parser)

    report_parser = subparsers.add_parser("report", help="Generate traceability report")
    add_common_flags(report_parser)
    report_parser.add_argument("--output", default="artifacts/traceability/traceability-report.md")

    release_parser = subparsers.add_parser("release-notes", help="Generate release notes")
    add_common_flags(release_parser)
    release_parser.add_argument("--output", default="artifacts/traceability/release-notes.md")
    release_parser.add_argument("--coverage-file", default="artifacts/coverage/coverage.cobertura.xml")

    args = parser.parse_args()

    stories_dir = pathlib.Path(args.stories_dir)
    stories, story_errors = discover_story_files(stories_dir)
    errors = list(story_errors)

    test_roots = [pathlib.Path(p) for p in args.tests_root] if args.tests_root else [pathlib.Path.cwd()]
    tests = discover_tests(test_roots)

    for story_id in stories:
        if story_id not in tests:
            errors.append(f"Story {story_id} has no associated tests")

    commit_map = {}
    if not args.skip_commits:
        commit_range = args.commit_range or os.environ.get("TRACEABILITY_COMMIT_RANGE", "")
        if not commit_range:
            commit_range = default_commit_range()
        try:
            commits = collect_commits(commit_range)
            if not commits:
                errors.append("No commits found in range for traceability validation")
            for sha, subject in commits:
                if not STORY_ID_RE.search(subject):
                    errors.append(f"Commit {sha} missing story ID: {subject}")
            commit_map = map_commits_to_stories(commits)
            for story_id in commit_map:
                if story_id not in stories:
                    errors.append(f"Commit references unknown story ID: {story_id}")
        except RuntimeError as exc:
            errors.append(str(exc))

    if args.command == "report":
        write_report(pathlib.Path(args.output), stories, tests, commit_map)
    elif args.command == "release-notes":
        coverage = parse_coverage_summary(pathlib.Path(args.coverage_file))
        write_release_notes(pathlib.Path(args.output), stories, tests, commit_map, coverage)

    if errors:
        for error in errors:
            print(f"ERROR: {error}")
        return 1
    print("Traceability validation passed")
    return 0


if __name__ == "__main__":
    sys.exit(main())
