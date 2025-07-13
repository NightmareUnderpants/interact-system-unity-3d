using System;
using UnityEngine;

public class PropInteract : MonoBehaviour, IInteractable
{
    [Header("Unavailiable Interaction")]
    [SerializeField]
    private bool isInteractable;
    [SerializeField]
    private string UnInteractiveText;

    [Header("Optional: Add height to InteractIcon transform")]
    [SerializeField]
    private float addHeight;

    public static event Action<string> OnInteract;

    public void Interact(Transform interactorTransform)
    {
        OnInteract?.Invoke(gameObject.name);
    }

    public void ChangeInteractState(bool state)
    {
        isInteractable = state;
    }

    public string GetInteractText()
    {
        return "Interact with Object";
    }

    public Transform GetInteractTransform()
    {
        return transform;
    }

    public Vector3 GetInteractVector3()
    {
        return new Vector3(transform.position.x, transform.position.y + addHeight, transform.position.z);
    }

    public string UnavailableIntegration()
    {
        return UnInteractiveText;
    }

    public bool IsInteractable()
    {
        return isInteractable;
    }
}
