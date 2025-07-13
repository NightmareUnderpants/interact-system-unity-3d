using System;
using UnityEngine;

public class ExampleInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool _isInteractable;

    public void Interact(Transform interactorTransform)
    {
        // interact logic
    }

    public void ChangeInteractState(bool state)
    {
        _isInteractable = state;
    }

    public Vector3 GetInteractVector3()
    {
        return new Vector3(transform.position.x, transform.position.y + addHeight, transform.position.z);
    }

    public bool IsInteractable()
    {
        return _isInteractable;
    }
}



