# SPEC.md
RORG Password Generator is a Windows Forms desktop application (.NET 8.0) that generates cryptographically strong passwords using local CSPRNG, atmospheric randomness via the random.org API, or a hybrid of both.
Iterative function adding and removal, for instance, if we run out of tokens, stop at the PREVIOUS feature request and only handle a full feature request.
Format used  1. and if there are subheadings such as a) b) c) d) e) etc..., process subheadings as part of one feature request.
"Last completed item was 26. Read CLAUDE.md and SPEC.md and continue from item 27."
## Feature Requests ##
````
1. Remove the copy to clipboard function on the main window
2. Verify compatibility with DEP, ASLR, NX and most mitigation options (CET) with Credguard and code integrity enabled. Correct for compiling either via user feedback or console output. << Mitigated via ProcessMitigation in Powershell/Windows
3. Support High-DPI and larger resolutions (1440p, 2560p, 100-200%DPI)
4. Unless mandatory, do not elevate and have it work for admin accounts (and SRPs enabled, standard)
5. Specialise the build for only i7-13700K processor on Z690-F chipset, no AVX512
	a) MMX through SSE4.2 and SSSE3, AVX, AVX2, FMA3, SHA, Intel 64,AES-NI, CLMUL, F16C, BMI1, BMI2, ABM, ADX, RdRand
6. Correct spelling mistakes and localise to English UK
7. Have the random function in Form1, refresh CSPRNG every 60 seconds if possible 
	a) currently it only pulls passwords from Random-Number Generator or  the API, so hybrid (so based on the setting set)
8. Make the setting take effect immediately on button change in integrated character set and maximum characters. Generate only passwords using max length onnly
9. Remove the function to export it into a file. 
10. Word-wrap generated password in the Result field, save generated passwords in the Result field in a new line prepended with its character set / size, time stamped for local time.
11. Write in parent directory for any generation failures (sharing log file with crashes)
12. Use integrated Character sets (and remove CharsMap folder), based on the following: 
	a) Alphanumeric + symbol range (safe for Web/oAuth services for instance)
	b) Alphanumeric + symbol range for *NIX and POSIX applications (latest versions [2025+] of *nix/POSIX systems)
	c) Azure/Cloud based Active Directory - kerberos support (full 95 ANSI character set)
	d) Everything possible in the UTF-16LE range (aside from forbidden characters)
13. Support up to 128 character, 64 characters, starting from minimum of 7 characters limit to 64 characters, but one can manually type in 128 characters (only), and value between 65-127 are invalid, and get corrected to previous value or 128 OR 7
14. Settings window should save to persistent directory: %appdata%\RORG\config.ini, have it load on app launch to read from it, and update it in the Settings directory.
15. Settings only needs Delay between API requests, safest minimum but also allowing user to specify any ms, and warning them for too low ms. remove API key field and hardcode free api key cff4f1e6-9e8d-4446-a4b2-ae57ac5550da
16. Remove Clear result box, and copy to clipboard functions in Settings application
17. Discard the buttons "What is API?" and "About this program" in Settings
18. Provide two buttons replacing "Discard changes" and "Save default settings" (of which saves it to config.ini)
19. in main window, show time in UTC and in local system time in a status bar below all results.
20. Show errors or catastrophic problems on status bar (time stamped by local time) and in window above "Generate!"
21. Use Windows 10+ only APIs and algorithms with CSPRNG and hybrid.
22. 3D field tables and buttons in Dark theme. (light theme not needed). utilising WinForms , software acceleration to avoid having to use the GPU..
23. Utilise Windows compatible fonts (serif, not sans serif) for all output in the GUI.
24. On application error, crash and output problems to a log file on the parent directory (csv or tlv.
25. Load default config values (%appdata%\RORG\config.ini) if it crashes. 
26. Add batch password generation
27. Remove debug streams and information from compiled exe and dll (-p:DebugType=pdbonly)
````
