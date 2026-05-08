# Replay and Memento Test Key Commands

## Recording Controls
- `J` — Start recording a new session.
- `K` — Stop recording the current session.
- `L` — Print all currently recorded mementos to the console.

## Replay Controls
- `N` — Begin replay playback using the test recording `RecordTest`.
- `M` — End the current replay playback.
- `C` — Clear all objects created by replay from the scene and destroy them.

## Playback Modification Controls (arrow keys)
- `Up Arrow` — Resume playback.
- `Down Arrow` — Toggle pause/resume during playback.
- `Left Arrow` — Rewind playback by 1 second.
- `Right Arrow` — Fast-forward playback by 1 second.

## Replay Object Behavior
- Replayed items are finalized for playback with gravity disabled.
- Replay objects are made kinematic so they can still be moved by the replay system.
- Colliders are disabled for replayed objects so they remain intangible and do not interfere with scene physics.
- Objects created during replay are tracked and destroyed when cleared to avoid memory buildup.

## Notes
- Replay uses `MementoSessionReplay.Instance.BeginPlayback("RecordTest")`, which loads the file `/RecordTest.json`.
- `Clear Replay Objects` will destroy all dynamically instantiated replay objects and remove stale replay player references.
