# Interact System Unity 3D

This simple Interact System easy way to drag&amp;put 3d objects, interact with them and a basic inventory system.
This system I use in my own game PERSEPTUAL. If you wanna know more go to [Links](#links).

## Available Languages
- [English](README.md)
- [Русский](README.ru.md)

## Include:
  - Interact with any object;
  - Place interactable object;
  - Put interactable object;
  - Put in Inventory any object.

This system include only Interact process and logic. And a few modest examples. (If you need more examples, I can add them from my game)

## How it works and how to use
### Simple Interact Object
1. Add [`IInteractable.cs`](/Scripts/Interact%20System/IInteractable.cs) and [`PlayerInteractManager.cs`](/Scripts/Interact%20System/PlayerInteractManager.cs) to project.
2. Create new .cs file and inherit `IInteractable`.
3. Implement all methods from `IInteractable`.  
   ![Example file Interact implement](/screenshots/interact%20example.png)
4. You can add your ideas in `void Interact()` its method called every time when you are interact with object.
   - Also you can change InputManager to simple processing via `if (Input.GetKeyDown(KeyCode.F))`.

### Interact Object

### Place Interact Object

### Inventory System

## Links
- TG Channel: [PERSEPTUAL GAME](https://t.me/nightmareunderpantsarts)
- Email: sasha_rsg@mail.ru
