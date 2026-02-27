---
trigger: model_decision
description: use this rule when work on Architecture specific tasks
globs: 
---

### Project Architecture (Deep Hierarchy Diagram)

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
- Place domain models in `Core/Domain/Models/`
- Keep Unity-specific code in Unity layer
- Maintain clean separation between layers