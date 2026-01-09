#!/usr/bin/env python3
import argparse
import pathlib
import re
import sys
from xml.etree import ElementTree


def parse_packages(path: pathlib.Path):
    tree = ElementTree.parse(path)
    root = tree.getroot()
    packages = []
    for package in root.findall(".//package"):
        name = package.attrib.get("name", "")
        line_rate = float(package.attrib.get("line-rate", "0"))
        branch_rate = float(package.attrib.get("branch-rate", "0"))
        packages.append({"name": name, "line": line_rate, "branch": branch_rate})
    return packages


def main() -> int:
    parser = argparse.ArgumentParser(description="Check coverage thresholds by package")
    parser.add_argument("--coverage-file", required=True)
    parser.add_argument("--min-line", type=float, default=0.8)
    parser.add_argument("--min-branch", type=float, default=0.8)
    parser.add_argument("--package-pattern", action="append", default=[])
    args = parser.parse_args()

    coverage_path = pathlib.Path(args.coverage_file)
    if not coverage_path.exists():
        print(f"ERROR: Coverage file not found: {coverage_path}")
        return 1

    packages = parse_packages(coverage_path)
    if not packages:
        print("ERROR: No packages found in coverage file")
        return 1

    patterns = args.package_pattern or [r"\\.Domain(\\.|$)", r"\\.Application(\\.|$)"]
    errors = []

    for pattern in patterns:
        matches = [p for p in packages if re.search(pattern, p["name"]) is not None]
        if not matches:
            errors.append(f"No packages matched pattern: {pattern}")
            continue
        for pkg in matches:
            if pkg["line"] < args.min_line:
                errors.append(
                    f"{pkg['name']} line coverage {pkg['line']:.2f} below {args.min_line:.2f}"
                )
            if pkg["branch"] < args.min_branch:
                errors.append(
                    f"{pkg['name']} branch coverage {pkg['branch']:.2f} below {args.min_branch:.2f}"
                )

    if errors:
        for error in errors:
            print(f"ERROR: {error}")
        return 1

    print("Coverage thresholds satisfied")
    return 0


if __name__ == "__main__":
    sys.exit(main())
