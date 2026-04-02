# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

RORG Password Generator is a Windows Forms desktop application (.NET 8.0) that generates cryptographically strong passwords using local CSPRNG, atmospheric randomness via the random.org API, or a hybrid of both.

```
## Build & Run Commands

### Output
- All builds output to `\bin` from project root
- Binary named `PGRNGvN` where N is auto-incremented from highest existing version in `\bin`
- x64 only, Release configuration

### Build Script (PowerShell)
Run `.\build.ps1` to compile. Script logic:
1. Scans `\bin` for existing `PGRNGv*.exe` files
2. Extracts highest N, increments by 1 (starts at 1 if none found)
3. Runs `dotnet publish` with `-o bin\` and `-p:AssemblyName=PGRNGvN`

### Manual MSBuild equivalent
```powershell
dotnet publish Pasword_generator.csproj -c Release -r win-x64 --self-contained false `
  -o bin\ -p:AssemblyName=PGRNGv1
```

### Run
```powershell
.\bin\PGRNGv[N].exe
```
### Core Forms
- **Form1.cs** — Main UI: password generation controls, triggers generation logic, displays results
- **Form2.cs** — Settings UI: request delay, default length, charset mode, generation type

### Key Classes
- **saveSettings.cs** — Reads/writes `C:\ProgramData\Rorg\config.ini`; all persistent state lives here

### Generation Modes (Form1)
Three generation types are selectable:
- **PureCSPRNGGen()** — Local only, uses `System.Security.Cryptography.RandomNumberGenerator`
- **rorgGen()** — Remote only, fetches random bytes from random.org JSON-RPC API
- **Hybrid** — Calls both, then combines via `MixWithHKDFBytes()` (HKDF-SHA256 with domain separation: `local || 0x01 || remote || 0x02`)

After generation, **`MapBytesToCharset()`** applies rejection sampling to map raw bytes to the selected character set without modular bias.

### Configuration Files (DefaultConfigs/)
Embedded defaults copied to parent directory instead of DefaultConfigs folder, link appropriately to the parent folder instead of DefaultConfigs
- `defaultSettings.ini` — default values for all settings
- `defaultSettingPath.ini` — path to user config (`C:\ProgramData\Rorg\config.ini`)

```
`saveSettings.LoadData(bool defaultPath)`: `false` loads user config; `true` loads embedded defaults. On missing/corrupt user config, automatically falls back to defaults recursively.

### random.org Integration
- JSON-RPC 2.0, methods: `generateBlobs` (primary), `generateStrings`, `generateIntegerSequences`
- Configurable request delay (default 100ms) to respect rate limits
- `rorgGen()` returns `PureCSPRNGGen()` if API is unavailable — no exception propagated to caller

### Non-obvious Implementation Details
- `Random` in Form1 is seeded from CSPRNG on form load (not time-based), but `Random` is only used for minor UI concerns — actual password bytes always come from `RandomNumberGenerator` or the API
- HKDF extraction uses a 32-byte zero salt (acceptable because the IKM is already high-entropy CSPRNG/API output)
- Iterative HKDF derivation: if the expanded key buffer is exhausted, re-derives with a counter appended to the info string (`"hybrid-hkdf-v1" + counter`), allowing unlimited output
- No NuGet packages compilation — only built-in .NET 8.0 libraries (`System.Security.Cryptography`, `System.Net.Http`, `System.Text.Json`)

### Data Flow
```
User selects: length + charset mode + generation type
    ↓
CSPRNG / rorgGen() / Hybrid
    ↓
MixWithHKDFBytes() [hybrid only]
    ↓
MapBytesToCharset() with rejection sampling
    ↓
Output password.
```
"Before starting SPEC.md, check whether the .csproj filename, AssemblyName, RootNamespace, and any file references are consistent with each other."
"Report any mismatches but do not fix them yet — ask me first."
If you correct them, check all file references, (savesettings.cs is important too) but leave the filenames intact

Refer to SPEC.md for feature requests. 
Process iteratively in order — complete each numbered item fully before proceeding. 
If context is near exhaustion, stop at the last fully completed item and report which item was last completed.
If there is a conflict with feature request, stop and ask user about direction.
Last completed item was 26. Read CLAUDE.md and SPEC.md and continue from item 27."
````