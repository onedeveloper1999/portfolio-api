PortfolioSolution
│
├── Portfolio.Application      (Application Layer)
│   ├── Interfaces              (Application service interfaces)
│   ├── Services                (Application service implementations)
│   └── Mapping                 (DTO to Entity mapping profiles)
│
├── Portfolio.Core             (Core Layer)
│   ├── Entities                (Core business entities)
│   ├── Interfaces              (Repositories and domain service interfaces)
│   ├── Enums                   (Enumeration types)
│   └── Exceptions              (Custom exceptions)
│
├── Portfolio.Infrastructure   (Infrastructure Layer)
│   ├── Data                    (DbContext and Entity Framework configuration)
│   ├── Repositories            (Data access implementations)
│   ├── Services                (External services or integrations)
│   └── Identity                (Identity and authentication configuration if needed)
│
├── Portfolio.WebApi           (Web API Layer)
│   ├── Controllers             (API controllers)
│   ├── Filters                 (Custom action filters)
│   ├── Startup.cs              (Dependency injection configuration)
│   └── Program.cs              (Entry point)
│
└── Portfolio.Tests            (Unit and integration tests)
    ├── ApplicationTests        (Tests for Application Layer)
    ├── CoreTests               (Tests for Core Layer)
    ├── InfrastructureTests     (Tests for Infrastructure Layer)
    └── WebApiTests             (Tests for Web API Layer)
