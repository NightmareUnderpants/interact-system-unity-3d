# Interact System Unity 3D

Эта простая система взаимодействия обеспечивает удобное перетаскивание и размещение 3D объектов, взаимодействие с ними и базовую систему инвентаря.  
Эту систему я использую в своей игре PERSEPTUAL. Если хотите узнать больше — смотрите [Ссылки](#links).

## Доступные языки
- [English](README.md)
- [Русский](README.ru.md)

## Включает в себя:
- Взаимодействие с любым объектом;
- Размещение интерактивных объектов;
- Подбор интерактивных объектов;
- Помещение объектов в инвентарь.

Эта система включает только процесс и логику взаимодействия, а также несколько простых примеров в репозитории. (Если нужно больше примеров — могу их добавить из своей игры.)

## Как это работает и как это использовать

### Simple Interact Object
1. Добавьте в проект файлы:
   - [`IInteractable.cs`](/Scripts/Interact%20System/IInteractable.cs)
   - [`PlayerInteractManager.cs`](/Scripts/Interact%20System/PlayerInteractManager.cs)
2. Создайте новый файл `.cs` и реализуйте интерфейс `IInteractable`.
3. Реализуйте все методы из `IInteractable`.  
   ```csharp
   public class ExampleInteract : MonoBehaviour, IInteractable
   {
       [SerializeField]
       private bool _isInteractable;

       public void Interact(Transform interactorTransform)
       {
           // логика взаимодействия
       }

       public void ChangeInteractState(bool state)
       {
           _isInteractable = state;
       }

       public Vector3 GetInteractVector3()
       {
           return transform.position;
       }

       public bool IsInteractable()
       {
           return _isInteractable;
       }
   }
  
5. В методе `void Interact()` вы можете добавить свою собственную логику —  
   этот метод вызывается каждый раз, когда вы взаимодействуете с объектом,  
   и метод `bool IsInteractable()` возвращает `true`.

6. Добавьте ваш новый компонент к вашему **GameObject**.

> [!WARNING]
> Не забудьте добавить компонент `Collider`!

### Interact Object

1. Добавьте в проект следующие файлы:
   - [`IInteractable.cs`](/Scripts/Interact%20System/IInteractable.cs)
   - [`PlayerInteractManager.cs`](/Scripts/Interact%20System/PlayerInteractManager.cs)
   - [`InteractObject.cs`](/Scripts/Interact%20System/InteractObject.cs)

2. У вас есть два варианта:
   - Создайте новый `.cs`‑файл, унаследованный от `InteractObject`, и реализуйте свою логику в методе `override void Interact()`.
   - Или просто добавьте компонент **InteractObject** к любому объекту через Inspector.

> [!WARNING]
> Не забудьте добавить компоненты `RigidBody` и `Collider`!

3. Настройте компонент **InteractObject** в Inspector:

   - **Name Object**  
     Присвойте объекту уникальное имя. Оно используется при вызове событий через `Invoke()`  
     (например, `OnObjectPicked<string>`).

   - **Interact Object State**  
     В 99% случаев достаточно состояния `Idle`. Это полезно для отладки и задания начального состояния.

   - **Is Interact**  
     Установите значение `false`, если планируете менять «интерактивность» объекта во время игры.

   - **Is Static Rotation**  
     В текущей версии объект должен иметь нулевую локальную ротацию или не менять её,  
     иначе вращение может вести себя непредсказуемо.

### Размещение интерактивного объекта  

### Система инвентаря  

## Ссылки
- **TG канал**: [PERSEPTUAL GAME](https://t.me/nightmareunderpantsarts)  
- **Email**: sasha_rsg@mail.ru
