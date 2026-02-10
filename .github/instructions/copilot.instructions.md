
# MCP Instructions
- Always use context7 MCP when I need library/API documentation, code generation, setup or configuratio
- Use unityMCP to interact with unity editor

# GitHub Copilot Instructions (Unity/C#)

- Target Unity C#; use Unity APIs and patterns.
- Use `SerializeField` on private fields instead of public fields; keep fields `readonly` where possible.
- Cache component references in `Awake`; use `Start` for runtime setup that depends on other components.
- Use `Update` for per-frame logic and `FixedUpdate` for physics; use `Time.deltaTime`/`Time.fixedDeltaTime`.
- Avoid per-frame allocations and LINQ in hot paths; reuse lists and buffers.
- Prefer `TryGetComponent` over `GetComponent` when possible.
- Prefer `ScriptableObject` for data/config instead of hard-coded values.
- Keep code safe for Unity main thread; avoid threading unless explicitly requested.
- Follow C# naming: PascalCase for types/methods, camelCase for locals/fields.

# Project Architecture (Deep Hierarchy Diagram

Project
├─ Shared                         ← Cross-cutting, data-only layer
│  └─ Constants                   ← Static identifiers and keys
│
├─ Core                           ← Logical core of the system
│  ├─ Domain                      ← Pure business logic (Unity-agnostic)
│  │  ├─ Models                   ← Domain entities (POCO)
│  │  └─ Contracts / Interfaces   ← System capability contracts
│  │
│  └─ Application                 ← Application flow & use-cases(Unity-agnostic)
│     ├─ StateMachine             ← Application lifecycle control
│     │  └─ States                ← Scenarios (Init, Menu, Game, etc.)
│     ├─ UseCases / Commands      ← Application actions
│     ├─ Application Models       ← Application-level state
│     └─ Services                 ← Coordinators (e.g. localization)
│     └─ Installers               ← Dependency injection Application classes and Interfaces setup (e.g. Zenject)
│
└─ Unity                          ← Technical / framework layer
   ├─ Bootstrap                   ← Startup & composition root
   │  ├─ GameInitializer          ← Main startup orchestrator
   │  └─ InitSteps                ← Initialization pipeline steps
   │
   ├─ Infrastructure              ← Unity → Domain adapters
   │  ├─ Scene Loading            ← IScenesLoader implementations
   │  ├─ Resources                ← IResourceManager implementations
   │  └─ Windows System           ← IWindowsController implementations
   │
   ├─ Installers                   ← Dependency injection Unity classes and Interfaces setup (e.g. Zenject)
   │
   └─ Presentation                ← UI / View layer
      ├─ Views / Screens          ← Screens and panels
      ├─ Windows                  ← UI windows
      └─ UI Components            ← Reusable visual components

- Use project architecture to add new files