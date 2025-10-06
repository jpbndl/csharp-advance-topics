# Common Intermediate Language (CIL)

CIL also known as Common Intermediate Language or IL, is a programming language that all .NET compatible languages like VB, C#, or F# gets compiled to.

## Compilation Flow Diagram

```
┌─────────────┐    ┌─────────────┐    ┌─────────────┐
│    C#       │    │    VB.NET   │    │    F#       │
│   Source    │    │   Source    │    │   Source    │
│    Code     │    │    Code     │    │    Code     │
└──────┬──────┘    └──────┬──────┘    └──────┬──────┘
       │                  │                  │
       ▼                  ▼                  ▼
┌─────────────┐    ┌─────────────┐    ┌─────────────┐
│ C# Compiler │    │ VB Compiler │    │ F# Compiler │
│   (csc.exe) │    │  (vbc.exe)  │    │  (fsc.exe)  │
└──────┬──────┘    └──────┬──────┘    └──────┬──────┘
       │                  │                  │
       └──────────┬───────────────────┬──────────┘
                  ▼               ▼
            ┌─────────────────────────────┐
            │     Common Intermediate     │
            │      Language (CIL)        │
            │        Assembly            │
            └─────────────┬───────────────┘
                          │
                          ▼
            ┌─────────────────────────────┐
            │    .NET Runtime (CLR)      │
            │   Just-In-Time (JIT)       │
            │       Compiler             │
            └─────────────┬───────────────┘
                          │
                          ▼
            ┌─────────────────────────────┐
            │     Native Machine Code     │
            │    (Platform Specific)      │
            └─────────────────────────────┘
```

## Key Points

- **Language Agnostic**: CIL provides a common target for all .NET languages
- **Platform Independent**: CIL code can run on any platform with a .NET runtime
- **JIT Compilation**: CIL is compiled to native code at runtime for optimal performance
- **Metadata Rich**: CIL assemblies contain both code and metadata about types and members