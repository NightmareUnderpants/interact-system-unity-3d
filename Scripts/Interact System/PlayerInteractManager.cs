using UnityEngine;

public class PlayerInteractManager : MonoBehaviour
{
    public static PlayerInteractManager Instance { get; private set; }

    [SerializeField]
    private Transform _hand;

    [SerializeField]
    private InteractObject _interactObject;
    public InteractObject InteractObject { get { return _interactObject; } }

    [HideInInspector]
    public bool lockInteract = false;

    public float interactRange = 3f; // Дистанция взаимодействия

    private Camera _cam;
    private PlayerInventoryManager _inventoryManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _inventoryManager = PlayerInventoryManager.Instance;
    }

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        if (!lockInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable Iinteractable = GetInteractable();
                if (Iinteractable != null)
                {
                    Debug.Log($"INTERACT WITH {Iinteractable}");
                    Iinteractable.Interact(transform);
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                _inventoryManager.CurrentInventoryObject.Interact();
            }

            // DEBUG
            if (Input.GetKeyDown(KeyCode.L))
            {
                _inventoryManager.SwitchObjectNext();
            }
        }
    }

    public IInteractable GetInteractable()
    {
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            IInteractable Iinteractable = hit.collider.GetComponent<IInteractable>();
            if (Iinteractable != null && Iinteractable.IsInteractable())
            {
                return Iinteractable;
            }
        }

        return null;
    }

    public void PickUpObject(InteractObject obj, bool isStaticRotation = false)
    {
        obj.transform.position = _hand.position;
        obj.transform.SetParent(_hand);

        _interactObject = obj;

        if (isStaticRotation)
            obj.transform.localEulerAngles = Vector3.zero;
    }

    public void PlaceObject(PlaceInteractObject place)
    {
        _interactObject.transform.SetParent(place.transform);
        _interactObject.transform.position = place.transform.position;
        _interactObject.transform.localEulerAngles = Vector3.zero;

        _interactObject.PlaceObject(place);

        _interactObject = null;
    }

    public void DestroyObject()
    {
        Destroy(_interactObject.gameObject);
        _interactObject = null;
    }

    public Transform GetHand()
    {
        return _hand;
    }
}