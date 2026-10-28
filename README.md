# CoopSyncEscape

A tiny Bloons TD 6 mod. When a co-op game gets stuck on the "Syncing / Waiting for other players" popup, it adds a **Menu** button to that popup so you can leave the match instead of waiting.

The button calls the popup's own `InGameQuit()`, the same quit the game uses itself.

## Requirements

- [MelonLoader](https://github.com/LavaGang/MelonLoader)
- [BTD6 Mod Helper](https://github.com/gurrenm3/BTD-Mod-Helper)

## Install

Put `CoopSyncEscape.dll` into the game's `Mods` folder.

## Build

```
dotnet build -c Release
```

By default the project looks for the game in `~/.local/share/Steam/steamapps/common/BloonsTD6`. Pass another folder with `-p:BloonsTD6=<path>`.
