# ShellcodeCarver
C# Shellcode Carving based off of [WoollyMammoth](https://github.com/ins1gn1a/WoollyMammoth) toolset.

![](https://img.shields.io/maintenance/yes/2021.svg)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/ins1gn1a/ShellcodeCarver.svg)](https://GitHub.com/ins1gn1a/ShellcodeCarver/pulls/)
[![GitHub issues](https://img.shields.io/github/issues/ins1gn1a/ShellcodeCarver)](https://github.com/ins1gn1a/ShellcodeCarver/issues)
[![GitHub license](https://img.shields.io/github/license/ins1gn1a/ShellcodeCarver.svg)](https://github.com/ins1gn1a/ShellcodeCarver/blob/master/LICENSE)

## Build
In the root directory use the relevant dotnet `RuntimeIdentifiers` value for x86 or x64:
```
# 32-bit
dotnet build -r win10-x86 -c "Release"

# 64-bit
dotnet build -r win10-x64 -c "Release"
```


## Usage

```
ShellcodeCarver.exe -h

Usage:  [options]

Options:
  -s | --shellcode <value>  Enter Shellcode as opcode format (e.g. \x64\x01)
  -e | --esp-start <value>  Enter ESP address value at start of carved shellcode
  -d | --esp-end <value>    Enter stack address value to write carved shellcode (allow for sufficient space for carved shellcode side)
  -b | --bad-chars <value>  Enter the bad characters withg the hex format separated by spaces, e.g. "0x00 0x01 0xff" or "00 01 ff"
  -f | --format <value>     Enable this option to preformat variable as P(ython)
  -? | -h | --help          Show help information
  ```
