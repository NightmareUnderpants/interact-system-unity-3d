using Unity.VisualScripting;
using UnityEngine;

public interface IInteractable
{
    void Interact(Transform interactorTransform);
    Vector3 GetInteractVector3();
    bool IsInteractable();
}
