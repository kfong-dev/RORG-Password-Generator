# RORG Password Generator
RORG Password Generator | C#, .NET 8.0, WinForms | Cryptographic password generator combining local CSPRNG and atmospheric noise via random.org API with HKDF-SHA256 hybrid mixing.  Rejection sampling on byte-to-charset mapping eliminates modular bias Hardened against DEP, ASLR, CFG, and CET — compatible with Credential Guard and code integrity environments

UI built with Winforms and .net v8

The hardcoded random.org API key (`cff4f1e6-9e8d-4446-a4b2-ae57ac5550da`) is a 
free public development key licensed for testing only — it is intentionally 
included in source and is not a secret. Production deployments should use a 
separately licensed key obtained from https://api.random.org/pricing

Original project and credit goes to 
John Nevzer Avrung (https://sourceforge.net/u/john-nevzer/profile/)
https://sourceforge.net/projects/pasword-generator-rorg/
