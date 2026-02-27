---
trigger: model_decision
description: use this rule when work on Unity/C# specific tasks
globs: ["**/*.cs"]
---

# Unity C# Development Rules

## Code Style and Formatting

### Naming Conventions
- **Classes and Interfaces**: PascalCase (e.g., `PlayerController`, `IGameService`)
- **Methods**: PascalCase (e.g., `InitializeGame()`, `UpdatePlayer()`)
- **Properties**: PascalCase (e.g., `PlayerName`, `ConnectionStatus`)
- **Fields**: 
  - Private/Protected: camelCase with underscore prefix (e.g., `_playerName`, `_connectionStatus`)
  - Public static readonly: PascalCase (e.g., `MaxPlayers`)
  - Constants: PascalCase (e.g., `DefaultSpeed`)
- **Local variables**: camelCase (e.g., `playerId`, `gameState`)
- **Parameters**: camelCase (e.g., `playerName`, `connectionStatus`)

### Code Organization
- **File structure**: One class per file, filename matches class name
- **Namespace organization**: Follow project architecture (Core.Domain, Core.Application, Unity.Presentation, etc.)
- **Using statements**: 
  - System namespaces first, then Unity, then project namespaces
  - Remove unused using statements
  - Use aliasing for conflicting names when necessary

### Formatting Rules
- **Indentation**: 3 spaces (project standard), no tabs
- **Braces**: Allman style - opening brace on new line
- **Line length**: Maximum 120 characters
- **Spacing**: 
  - Space after commas and semicolons
  - Space around operators (+, -, *, /, =, ==, !=, etc.)
  - No space before opening parenthesis in method calls
  - Space after keywords (if, for, while, switch, catch)
- **Blank lines**: 
  - One blank line between methods
  - Two blank lines between different logical sections
  - No blank lines at start/end of file

### Unity-Specific Patterns
- **Serialization**: Use `SerializeField` on private fields instead of public fields
- **Component Access**: 
  - Cache component references in `Awake()`
  - Use `TryGetComponent()` over `GetComponent()` when possible
  - Use `GetComponent<T>()` with explicit type parameter
- **Lifecycle Methods**:
  - `Awake()`: Cache references, initialize internal state
  - `Start()`: Runtime setup that depends on other components
  - `Update()`: Per-frame logic (use `Time.deltaTime`)
  - `FixedUpdate()`: Physics calculations (use `Time.fixedDeltaTime`)
- **Performance**:
  - Avoid per-frame allocations in hot paths
  - Reuse collections and buffers
  - Avoid LINQ in performance-critical code
  - Use object pooling for frequently instantiated objects

### Dependency Injection (Zenject)
- **Injection**: Use `[Inject]` attribute on private fields
- **Installer pattern**: Separate installers for different layers
- **Interfaces**: Inject interfaces, not concrete implementations
- **Factory pattern**: Use factories for creating instances at runtime

### Error Handling
- **Null checks**: Use null-conditional operators and null-coalescing
- **Validation**: Validate parameters in public methods
- **Logging**: Use appropriate logging levels
- **Exception handling**: Handle specific exceptions, avoid catch-all blocks

### Documentation
- **Public APIs**: XML documentation for public methods and classes
- **Complex logic**: Comments explaining business logic
- **TODO/FIXME**: Use standard tags with clear descriptions

