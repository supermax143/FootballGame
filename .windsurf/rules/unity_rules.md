---
trigger: always_on
description: 
globs: 
---

# Unity C# Development Rules

- Target Unity C#; use Unity APIs and patterns.
- Use `SerializeField` on private fields instead of public fields; keep fields `readonly` where possible.
- Cache component references in `Awake`; use `Start` for runtime setup that depends on other components.
- Use `Update` for per-frame logic and `FixedUpdate` for physics; use `Time.deltaTime`/`Time.fixedDeltaTime`.
- Avoid per-frame allocations and LINQ in hot paths; reuse lists and buffers.
- Prefer `TryGetComponent` over `GetComponent` when possible.
- Prefer `ScriptableObject` for data/config instead of hard-coded values.
- Keep code safe for Unity main thread; avoid threading unless explicitly requested.
- Follow C# naming: PascalCase for types/methods, camelCase for locals/fields.