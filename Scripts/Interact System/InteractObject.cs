using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class InteractObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string _nameObject;
    [SerializeField]
    private bool _isInteract = true;
    [SerializeField]
    private bool _isStaticRotation = true;

    public enum InteractObjectState
    {
        Idle,
        Picked,
        Placed,
    }
    [SerializeField]
    private InteractObjectState _interactState = InteractObjectState.Idle;

    private PlaceInteractObject _place;

    private Rigidbody _rb;
    private Collider _collider;

    public event Action<string> OnObjectPlaced;
    public event Action<string> OnObjectPicked;
    public event Action<string> OnObjectInteract;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public virtual void Interact(Transform interactorTransform)
    {
        switch (_interactState)
        {
            case InteractObjectState.Idle:
                PickUpObject();
                break;
            //case InteractObjectState.Picked:
            //    PlaceObject();
            //    break;
            case InteractObjectState.Placed:
                _place.HandleInteractObjectInPlace();
                OnObjectInteract?.Invoke(name);
                break;
        }
    }

    public void PickUpObject()
    {
        _interactState = InteractObjectState.Picked;
        SetInteract(false);

        _rb.isKinematic = true;
        _rb.useGravity = false;

        PlayerInteractManager.Instance.PickUpObject(this, _isStaticRotation);

        OnObjectPicked?.Invoke(_nameObject);
    }

    public void PlaceObject(PlaceInteractObject place)
    {
        _interactState = InteractObjectState.Placed;
        SetInteract(true);

        _rb.isKinematic = true;
        _rb.useGravity = false;

        _place = place;

        OnObjectPlaced?.Invoke(_nameObject);
    }

    public Vector3 GetInteractVector3() => transform.position;
    public bool IsInteractable() => _isInteract;
    public void SetInteract(bool state) => _isInteract = state;
}
