# Domain Driven Design (DDD) Architecture

Domain Driven Design is an approach to solving complex problems by breaking them into smaller, more manageable parts and focusing on problems that are relatively easier to solve.
A complex domain may contain subdomains, and some subdomains can be combined and grouped together based on common rules and responsibilities.

## Two Types of DDD

- **Strategic DDD** - Understanding and modeling the business domain. It involves identifying different domains, their subdomains, and how they interact with each other.
- **Tactical DDD** - Implementation details and design patterns, including patterns like Entities, Value Objects, Aggregates, etc.

## DDD Concepts

### Domain
- The sphere of knowledge and activity around which the application logic revolves.
- Represents the problem space - the area of expertise or business need that the software addresses.

### Subdomain
- Represents a specific area of expertise within the overall domain.

### Ubiquitous Language
- Common language used by developers and domain experts to ensure clarity and consistency.
- It is crucial for this language to be used in both discussions and in the codebase.

### Bounded Context
- Grouping of closely related scopes that define logical boundaries.
- Logical boundary that represents smaller problem particles of the complex domain that are self-consistent and as independent as possible.
- Each bounded context can have its own database schema, code models, and team working on it.

### Context Mapping Pattern
- Identifies all bounded contexts in the application along with their logical boundaries.
- A way to define logical boundaries between domains.

## DDD Building Blocks (Tactical Patterns)

### Entity
- Objects that have a distinct identity that runs through time and different representations.
- Defined by their identity rather than their attributes.

### Value Object
- Objects that describe characteristics of things but have no conceptual identity.
- Immutable and defined by their attributes.

### Aggregate
- A cluster of domain objects that can be treated as a single unit.
- Has one Aggregate Root that controls access to the aggregate.

### Repository
- Encapsulates the logic needed to access data sources.
- Provides a more object-oriented view of the persistence layer.

### Domain Service
- Contains domain logic that doesn't naturally fit within an entity or value object.
- Stateless operations that work with domain objects.

### Domain Events
- Something that happened in the domain that domain experts care about.
- Used to trigger side effects and maintain consistency across aggregates.

