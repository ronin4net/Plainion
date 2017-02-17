## 3.0.0 - 2016-08-13

- Major improvement of documentation
- UnitTests added
- IO Filesystem abstraction reworked
  - FileSystem.UnifyPath: filesystem parameter removed
  - IFile.Move renamed to IFile.MoveTo
  - FileSystem.CopyTo moved to IFile.CopyTo
  - IDirectory.GetFiles() APIs renamed to EnumerateFiles and return an iterator now. 
    Convenience methods provided as extension methods so that implementations can be shared across filesystem implementations.
  - IFile.ReadAllLines and WriteAll converted into extension methods so that implementations can be shared across filesystem implementations.
- Logging framework reworked to make it easier to extend
  - BREAKING change: the application now always has to provide a logging sink
  - LoggerFactory.LoadConfiguration removed
  - ILoggerFactoringImpl renamed to ILoggerFactory
  - Most extensible classes renamed and simplified
- Processes utility moved from "IO" namespace to "Diagnostics" namespace
  