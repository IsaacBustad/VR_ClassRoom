# Copilot Rules

This repository uses a small rule set for AI-assisted edits.

- Do not create any additional serialized fields.
- Do not create unnecessary accessors.
- Follow existing code structure, naming, and visibility patterns.
- Keep changes minimal and local to the issue being fixed.
- Prefer `protected` fields and methods where existing classes already use them.
- Avoid introducing new public API unless required for the bug fix.

# Specific to Memento replay

- Disable gravity for factory items created during replay playback.
- Ensure `memID` is assigned to `MementoPlayer` during playback.
- Preserve `id` and `instanceID` values through recording and replay.
