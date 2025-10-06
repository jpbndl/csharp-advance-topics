# Common Language Runtime (CLR)

CLR also known as Common Language Runtime is a runtime environment that manages execution of .NET applications.

## CLR Architecture Diagram

```
┌─────────────────────────────────────────────────────────────────────┐
│                        .NET Application                            │
└─────────────────────────┬───────────────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────────────┐
│                   Common Language Runtime (CLR)                    │
├─────────────────────────────────────────────────────────────────────┤
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐    │
│  │   Class Loader  │  │  JIT Compiler   │  │ Exception       │    │
│  │                 │  │                 │  │ Manager         │    │
│  └─────────────────┘  └─────────────────┘  └─────────────────┘    │
│                                                                     │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐    │
│  │ Garbage         │  │ Security        │  │ Thread          │    │
│  │ Collector (GC)  │  │ Manager         │  │ Manager         │    │
│  └─────────────────┘  └─────────────────┘  └─────────────────┘    │
│                                                                     │
│  ┌─────────────────────────────────────────────────────────────┐  │
│  │                    Memory Manager                          │  │
│  │  ┌─────────────┐  ┌─────────────┐  ┌─────────────────┐    │  │
│  │  │    Stack    │  │    Heap     │  │  Method Area    │    │  │
│  │  └─────────────┘  └─────────────┘  └─────────────────┘    │  │
│  └─────────────────────────────────────────────────────────────┘  │
└─────────────────────────┬───────────────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────────────┐
│                    Operating System                                │
│                   (Windows, Linux, macOS)                          │
└─────────────────────────────────────────────────────────────────────┘
```

## Key CLR Components

- **Class Loader**: Loads types and assemblies into memory
- **JIT Compiler**: Converts CIL to native machine code at runtime
- **Garbage Collector**: Automatically manages memory allocation and deallocation
- **Exception Manager**: Handles structured exception handling across languages
- **Security Manager**: Enforces code access security and permissions
- **Thread Manager**: Manages multithreading and synchronization
- **Memory Manager**: Organizes memory into stack, heap, and method areas
