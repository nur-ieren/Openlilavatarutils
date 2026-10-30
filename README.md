# Openlilavatarutils

A Unity Editor shortcut for opening lilAvatarUtils with a selected GameObject.

## Concept

Openlilavatarutils was created to simplify access to lilAvatarUtils during avatar editing.

Instead of opening lilAvatarUtils separately and manually assigning a GameObject, this tool adds a shortcut to the GameObject context menu.

Selecting the shortcut opens the lilAvatarUtils editor window and attempts to assign the selected GameObject as its target.

## Overview

- **Unity Version:** 2022.3.22f1
- **Menu:** `GameObject > Open lilAvatarUtils`
- **Dependency:** lilAvatarUtils

## Features

- **Context Menu Shortcut** — Opens lilAvatarUtils from the GameObject context menu.
- **Automatic Target Assignment** — Attempts to assign the selected GameObject to the opened window.
- **No Direct Assembly Reference** — Uses reflection to locate and interact with lilAvatarUtils, avoiding a direct compile-time dependency.
- **Dependency Check** — Displays a warning dialog if a compatible lilAvatarUtils editor window cannot be found.

## Requirements

- Unity 2022.3.22f1
- lilAvatarUtils installed in the Unity project

## How to use

1. Install lilAvatarUtils in your Unity project.
2. Open your avatar project.
3. Select or right-click the GameObject you want to work with in the Hierarchy.
4. Choose `Open lilAvatarUtils` from the GameObject context menu.

The tool opens the lilAvatarUtils window and attempts to assign the selected GameObject automatically.

## Important notes

- The context menu is available for selected scene GameObjects, not persistent project assets.
- Target assignment uses reflection to find a suitable field in the lilAvatarUtils editor window.
- Compatibility depends on the internal structure of lilAvatarUtils. Changes to its window type or target fields may affect automatic assignment.

## Development

This project was created to reduce repetitive steps when opening lilAvatarUtils for a particular GameObject.

## Author

- nur_ieren
- vor_ges

## Licence

This project is licensed under the MIT License, see the LICENSE file for details.

[MIT License](https://opensource.org/license/mit)
