# CheckSum
## Change Log
Ver 2.0-Beta
 - Refactored the project.
 - New WPF GUI
 - Refactor the Core library to accept different hash algorithm supported
 - Allowed hash algorithm dynamicly loaded during runtime. (Hot reload not supported yet)
 - Multi-thread hashing supported.

## TODO
 - Multi-file hashing.
 - Commandline tool
 - Make custom algorithm

## Description
It is checksum tool make by C# where has GUI and Commandline shared the same library. (Commandline is not yet completed.)
The core library are extenable with dll, all extension should implement the interface IHashProcessor, a abstract base class HashProcessorBase is provided.
Two example projects MD5 and SHA is provided in the Extension directory.