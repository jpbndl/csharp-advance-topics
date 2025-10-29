# Clean Architecture

A software architecture pattern created by Robert C. Martin that separates concerns and creates systems independent of frameworks, UI, and databases. This promotes maintainable, testable, and adaptable systems through the **Dependency Rule**: dependencies point inward toward the business logic.

## Core Principles

- **Independence of Frameworks** - The system is not tightly coupled to specific frameworks, making it adaptable to changes in tools and technologies.
- **Testable** - Business rules can be tested without UI, database, web server, or any external elements.
- **UI Independent** - The UI can change without affecting the business rules or other system components.
- **Database Independent** - Business rules are not bound to any specific database technology.
- **External Agency Independent** - Business rules don't depend on external systems or services.

## The Four Layers (Inside-Out)

### 1. Entities (Enterprise Business Rules)
- **Purpose**: Contains enterprise-wide business rules and core domain logic
- **Dependencies**: None (innermost layer)
- **Examples**: `Order`, `Customer`, `Product` domain entities
- **Characteristics**: Pure business objects with no external dependencies

### 2. Use Cases (Application Business Rules)
- **Purpose**: Contains application-specific business rules and orchestrates data flow
- **Dependencies**: Only depends on Entities layer
- **Examples**: `CreateOrderUseCase`, `ProcessPaymentUseCase`, `GetCustomerOrdersUseCase`
- **Characteristics**: Defines interfaces for data access and external services

### 3. Interface Adapters (Controllers, Gateways, Presenters)
- **Purpose**: Converts data between use cases and external systems
- **Dependencies**: Depends on Use Cases and Entities layers
- **Examples**: REST controllers, database repositories, external API clients
- **Characteristics**: Implements interfaces defined in the Use Cases layer

### 4. Frameworks & Drivers (External Interfaces)
- **Purpose**: Contains frameworks, tools, and external systems
- **Dependencies**: Depends on all inner layers
- **Examples**: Web frameworks, databases, external services, UI components
- **Characteristics**: Most volatile layer, changes frequently

## Clean Architecture Diagram

```
┌─────────────────────────────────────────────────────────────┐
│                    FRAMEWORKS & DRIVERS                    │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐ │
│  │     Web     │  │  Database   │  │   External APIs     │ │
│  │ Controllers │  │   (EF Core) │  │   File System       │ │
│  └─────────────┘  └─────────────┘  └─────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                   INTERFACE ADAPTERS                       │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐ │
│  │ Controllers │  │ Repositories│  │     Presenters      │ │
│  │   Gateways  │  │   Mappers   │  │      Adapters       │ │
│  └─────────────┘  └─────────────┘  └─────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                      USE CASES                             │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐ │
│  │ Application │  │  Use Case   │  │     Interfaces      │ │
│  │  Services   │  │ Interactors │  │   (Repositories)    │ │
│  └─────────────┘  └─────────────┘  └─────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                       ENTITIES                             │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐ │
│  │   Domain    │  │   Business  │  │    Value Objects    │ │
│  │  Entities   │  │    Rules    │  │   Domain Services   │ │
│  └─────────────┘  └─────────────┘  └─────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

## Core vs Periphery Layers

```
┌─────────────────────────────────────────────────────────────┐
│                      PERIPHERY LAYERS                      │
│  ┌─────────────────────────────────────────────────────┐   │
│  │              INFRASTRUCTURE LAYER                  │   │
│  │    • Database Implementations                       │   │
│  │    • External API Clients                          │   │
│  │    • File System Access                            │   │
│  │    • Message Queues                                │   │
│  └─────────────────────────────────────────────────────┘   │
│  ┌─────────────────────────────────────────────────────┐   │
│  │               PRESENTATION LAYER                   │   │
│  │    • Web Controllers                                │   │
│  │    • API Endpoints                                  │   │
│  │    • UI Components                                  │   │
│  │    • Request/Response Models                        │   │
│  └─────────────────────────────────────────────────────┘   │
│                            │                               │
│                            ▼                               │
│  ┌─────────────────────────────────────────────────────┐   │
│  │                 CORE LAYERS                        │   │
│  │  ┌─────────────────────────────────────────────┐   │   │
│  │  │           APPLICATION LAYER                 │   │   │
│  │  │    • Use Cases                              │   │   │
│  │  │    • Application Services                   │   │   │
│  │  │    • Interfaces (Contracts)                 │   │   │
│  │  │    • DTOs                                   │   │   │
│  │  └─────────────────────────────────────────────┘   │   │
│  │                      │                             │   │
│  │                      ▼                             │   │
│  │  ┌─────────────────────────────────────────────┐   │   │
│  │  │             DOMAIN LAYER                    │   │   │
│  │  │    • Entities                               │   │   │
│  │  │    • Value Objects                          │   │   │
│  │  │    • Domain Services                        │   │   │
│  │  │    • Business Rules                         │   │   │
│  │  └─────────────────────────────────────────────┘   │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
```

## Dependency Rule

**Critical**: Dependencies must point **inward only**. Inner layers cannot know about outer layers.

```
Periphery → Core
Infrastructure → Application → Domain
Presentation → Application → Domain
```

## Clean Architecture with DDD Implementation

### Core Layers (Business Logic)
- **Domain Layer**
  - Contains entities, value objects, domain services, and business rules
  - No dependencies on external frameworks or infrastructure
  - Pure C# classes with domain logic

- **Application Layer**
  - Contains use cases, application services, and interfaces
  - Defines contracts for infrastructure (repositories, external services)
  - Orchestrates domain objects to fulfill business requirements

### Infrastructure Layers (Technical Concerns)
- **Infrastructure Layer**
  - Implements interfaces defined in Application layer
  - Contains data access, external API clients, file systems
  - Uses Entity Framework, HTTP clients, message queues

- **Presentation Layer**
  - Contains controllers, views, API endpoints
  - Handles HTTP requests/responses, user input validation
  - Depends on Application layer through dependency injection

## .NET Project Structure & References

```
┌─────────────────────────────────────────────────────────────┐
│                        API PROJECT                         │
│                    (Presentation Layer)                    │
│  ┌─────────────────┐              ┌─────────────────────┐  │
│  │   References:   │              │     Contains:       │  │
│  │ • Application   │              │ • Controllers       │  │
│  │ • Infrastructure│              │ • Program.cs        │  │
│  └─────────────────┘              │ • Startup.cs        │  │
│                                   │ • Middleware        │  │
│                                   └─────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
                    │                        │
                    ▼                        ▼
┌─────────────────────────────┐    ┌─────────────────────────────┐
│     INFRASTRUCTURE          │    │       APPLICATION           │
│                             │    │                             │
│  ┌─────────────────┐        │    │  ┌─────────────────┐        │
│  │   References:   │        │    │  │   References:   │        │
│  │ • Application   │        │    │  │ • Domain        │        │
│  └─────────────────┘        │    │  └─────────────────┘        │
│                             │    │                             │
│  ┌─────────────────┐        │    │  ┌─────────────────┐        │
│  │    Contains:    │        │    │  │    Contains:    │        │
│  │ • Repositories  │        │    │  │ • Use Cases     │        │
│  │ • DbContext     │        │    │  │ • Interfaces    │        │
│  │ • External APIs │        │    │  │ • Services      │        │
│  │ • File System   │        │    │  │ • DTOs          │        │
│  └─────────────────┘        │    │  └─────────────────┘        │
└─────────────────────────────┘    └─────────────────────────────┘
                    │                        │
                    └──────────┬─────────────┘
                               ▼
                ┌─────────────────────────────┐
                │           DOMAIN            │
                │                             │
                │  ┌─────────────────┐        │
                │  │   References:   │        │
                │  │ • NONE          │        │
                │  └─────────────────┘        │
                │                             │
                │  ┌─────────────────┐        │
                │  │    Contains:    │        │
                │  │ • Entities      │        │
                │  │ • Value Objects │        │
                │  │ • Domain Events │        │
                │  │ • Business Rules│        │
                │  └─────────────────┘        │
                └─────────────────────────────┘
```

## Project Reference Flow

```
API → Application + Infrastructure
Infrastructure → Application
Application → Domain
Domain → (No References)
```

**Why this structure works:**
- **API** can access both Application (for use cases) and Infrastructure (for DI registration)
- **Infrastructure** implements interfaces defined in Application
- **Application** defines business logic and depends only on Domain
- **Domain** has zero dependencies (pure business logic)

## Benefits
- **Maintainability**: Clear separation of concerns
- **Testability**: Business logic isolated from external dependencies
- **Flexibility**: Easy to swap implementations (database, UI, frameworks)
- **Scalability**: Each layer can evolve independently