# Interact System Unity 3D

This simple Interact System easy way to drag&amp;put 3d objects, interact with them and a basic inventory system.
This system I use in my own game PERSEPTUAL. If you wanna know more go to [Links](#links).

## Available Languages
- [English](README.md)
- [Русский](README.ru.md)

## Include:
  - Interact with any object;
  - Place interactable object;
  - Pick interactable object;
  - Pick in Inventory any object.

This system include only Interact process and logic. And a few modest examples. (If you need more examples, I can add them from my game)

## How it works and how to use
### Simple Interact Object
1. Add [`IInteractable.cs`](/Scripts/Interact%20System/IInteractable.cs) and [`PlayerInteractManager.cs`](/Scripts/Interact%20System/PlayerInteractManager.cs) to project.
2. Create new .cs file and inherit `IInteractable`.
3. Implement all methods from `IInteractable`.  
   ![Example file Interact implement](/screenshots/interact%20example.png)
4. You can add your ideas in `void Interact()` its method called every time when you are interact with object and `bool IsInteractable()` returns `True`.
5. Add this new component to your GameObject
  > [!WARNING]
  > Don't forget add Colliders component!

### Interact Object
1. Add [`IInteractable.cs`](/Scripts/Interact%20System/IInteractable.cs), [`PlayerInteractManager.cs`](/Scripts/Interact%20System/PlayerInteractManager.cs) and [`InteractObject.cs`](/Scripts/Interact%20System/InteractObject.cs) to project.

3. On this step you have 2 options for what to do next.

  1. Create new .cs file, inherit `InteractObject` and implement you own logic in `override void Interact()`.
  2. Or add this component in Inspector to any object.
  > [!WARNING]
  > Don't forget add RigidBody and Colliders component!

3. Add component in Inspector to your GameObject and set it up.

  - `Name Object`: write name to your object. Its need to recognize this object when you `Invoke()` actions like `OnObjectPicked<string>`;
  - `Interact Object State`: at 99% of cases you need only Idle state. Its can helpfuly for Debugging states of this object and set initial state.
  - `Is Interact`: set it `False` if you change _"Interactability"_ that object later.
  - `Is Static Rotation`: In this version object can only being in zero local rotation or not change local rotation because of this, the rotation of object is unpredictable.


### Place Interact Object

### Inventory System

## Links
- TG Channel: [PERSEPTUAL GAME](https://t.me/nightmareunderpantsarts)
- Email: sasha_rsg@mail.ru
