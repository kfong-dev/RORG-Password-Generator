# RORG Password Generator
RORG Password Generator | C#, .NET 8.0, WinForms | Cryptographic password generator combining local CSPRNG and atmospheric noise via random.org API with HKDF-SHA256 hybrid mixing.  Rejection sampling on byte-to-charset mapping eliminates modular bias Hardened against DEP, ASLR, CFG, and CET — compatible with Credential Guard and code integrity environments
