using Unity.VisualScripting;
using UnityEngine;

public class FlashlightInventoryObject : MonoBehaviour, IInventoryObject
{
    [SerializeField]
    private bool _isInteract = true;

    [SerializeField]
    private string _nameItem;

    [SerializeField] private Vector3 offsetPositionInHand;
    [SerializeField] private Vector3 offsetRotationInHand;

    private PlayerInventoryManager _playerInventory;

    private Light _light;

    private void Start()
    {
        _playerInventory = PlayerInventoryManager.Instance;

        _light = GetComponentInChildren<Light>();

        if (TryGetComponent<InteractObject>(out var interactObject))
        {
            interactObject.OnObjectPicked += HandlePickup;
        }
    }

    public void Interact()
    {
        if (!_isInteract) return;

        _light.enabled = !_light.enabled;
    }

    public void EnableObject() => gameObject.SetActive(true);
    public void DisableObject() => gameObject.SetActive(false);

    private void HandlePickup(string itemName)
    {
        if (itemName != _nameItem) return;

        if (TryGetComponent<InteractObject>(out var interactComponent))
        {
            Destroy(interactComponent);
        }

        PlayerInventoryManager.Instance.AddObjectToInventory(this);
    }

    private void OnDestroy()
    {
        if (TryGetComponent<InteractObject>(out var interactObject))
        {
            interactObject.OnObjectPicked -= HandlePickup;
        }
    }

    public MonoBehaviour GetMonoBehaviour() => this;
    public Vector3 GetOffsetPosition() => offsetPositionInHand;
    public Vector3 GetOffsetRotation() => offsetRotationInHand;
}
