using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlaceInteractObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool _isInteract = false;

    [SerializeField]
    private string _nameObject = null;

    public List<InteractObject> interactObjectList = new List<InteractObject>();

    private Collider _collider;

    public event Action<string> OnObjectPlaced;
    public event Action<string> OnObjectInteract;

    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public virtual void Interact(Transform interactorTransform)
    {
        var interactObjectInHand = PlayerInteractManager.Instance.InteractObject;
        if (interactObjectInHand == null)
            return;

        foreach (var interactObject in interactObjectList)
        {
            if (interactObjectInHand == interactObject)
            {
                PlaceObject();
                interactObjectList.Remove(interactObject);
                CheckListForEmpteness();
                return;
            }
        }
    }

    private void CheckListForEmpteness()
    {
        if (interactObjectList.Count > 0) return;

        _isInteract = false;
    }

    protected virtual void PlaceObject()
    {
        PlayerInteractManager.Instance.PlaceObject(this);

        OnObjectPlaced?.Invoke(_nameObject);
    }

    public virtual void HandleInteractObjectInPlace()
    {
        // Base logic not exists

        OnObjectInteract?.Invoke(_nameObject);
    }

    public Vector3 GetInteractVector3()
    {
        return transform.position;
    }

    public bool IsInteractable()
    {
        return _isInteract && interactObjectList.Count > 0;
    }

    public void SetInteract(bool state)
    {
        _isInteract = state;
    }
}
