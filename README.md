# CheckSum

## Change Log
Ver 2.0-release
 - Refactored the project.
 - New WPF GUI
 - Refactor the Core library to accept different hash algorithm supported. Must implement `IHashProcessor`
 - Allowed hash algorithm dynamicly loaded during runtime. (Hot reload not supported yet)
 - Multi-thread hashing supported.
 - Commandline tool
 - Make custom algorithm possible `IHashAlgorithm` (No example provided yet)

## TODO
 - Multi-file hashing.
 - Make all current hash algorithm implement `IHashProcessor`

## Description
It is checksum tool make by C# where has GUI and Commandline shared the same library. (Commandline is not yet completed.)
The core library are extenable with dll, all extension should implement the interface `IHashProcessor`, a abstract base class `HashProcessorBase` is provided if you want to use the algorithm provided by Microsoft in `System.Security.Cryptography`. A abstract base class `CustomHashProcessorBase` is provided is you want to use custom algorithm.
Two example projects `MD5` and `SHA` is provided in the Extension directory.

