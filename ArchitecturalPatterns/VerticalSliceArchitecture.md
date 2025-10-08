# Vertical Slice Architecture

- Offers architecture **against to traditional layered, Onion and Clean Architecture** approaches.
- Aims to **organize code around specific features or use cases**, rather than the technical concenrns.
- Feature is implemented **across all layers of the software**, from the UI to the database.
- Often used in development of **complex, feature-rich** apps.
- **Divide** application into **distinct features** or **functionalities**, each of which cuts through all the layers of the application.
- **Contrast to traditional n-tier** or **layered architecture**, where the application is divided **horizontally**

## Characterestics of Vertical Slice Architecture
- The application is divided **into feature-based slices**
- **Each slice** is **self-contained** and **inependent**
- **Reduced dependencies** between different parts of the applciation
- It **promotes** the use of **cross-functional teams**
- The architecture **supports scalability** and **maintainabiity**
- It allows for **improved testing** AND **deployment** processes
- **Every microservices handles** and **specific piece of functionality** and communicates with other services through well-defined interfaces.

## Benefits & Challenges
### Benefits
- Focused development, teams can concentrate on one feature at a time
- Simplifies refactoring and upgrades since changes in one slice usually don't affect others
- Aligns well with Agile and DevOps practices, supporting incremental development and continuous delivery

### Challenges
- Duplication of code across slices, particularlry for common functionalities
- Learning curve involved, especially for teams accustomed to traditional architectures
- Design of eac slice **requires careful consideration to ensure independence and maintainability**

## Vertical Slice Architecture vs Clean Architecture

| Aspect             | Vertical Slice Architecture         | Clean Architecture                     |
| ------------------ | ----------------------------------- | -------------------------------------- |
| **Organization**   | Feature-based slices                | Layer-based (horizontal)               |
| **Dependencies**   | Each slice is independent           | Dependency inversion (inner → outer)   |
| **Code Location**  | All layers in one feature folder    | Separated by technical concerns        |
| **Coupling**       | Low coupling between features       | Low coupling between layers            |
| **Team Structure** | Cross-functional teams per feature  | Teams organized by technical expertise |
| **Testing**        | Feature-focused integration tests   | Layer-specific unit tests              |
| **Deployment**     | Feature-by-feature deployment       | Full application deployment            |
| **Code Reuse**     | Potential duplication across slices | Shared abstractions and interfaces     |
| **Complexity**     | Simple for small features           | Complex dependency management          |
| **Scalability**    | Horizontal scaling per feature      | Vertical scaling by layer              |
| **Maintenance**    | Isolated feature changes            | Cross-layer impact analysis            |
| **Learning Curve** | Moderate (feature-focused)          | Steep (architectural principles)       |


## When to choose Vertical Slice over Clean Architecture
- **Rapid Development & Deployment** - when the prioirty is to develop and deploy features rapidly and indepenently
- **Agile & Scrum Teams** - when agile teams prioirty is to deliver a feature in short sprint
- **Microservices** - wher each service is often responsible for a distinct feature or business capability