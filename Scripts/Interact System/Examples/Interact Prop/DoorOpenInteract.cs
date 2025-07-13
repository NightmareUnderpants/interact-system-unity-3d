using UnityEngine;

public class DoorOpenInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string UnInteractiveText;
    [SerializeField]
    private bool isInteract = false;

    [SerializeField]
    private float addHeight;
    private Animator anim;

    private bool isOpenDoor = false;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    void IInteractable.Interact(Transform interactorTransform)
    {
        isOpenDoor = !isOpenDoor;
        if (isOpenDoor) anim.SetBool("open_door", true);
        else anim.SetBool("open_door", false);
    }

    public Vector3 GetInteractVector3()
    {
        return new Vector3(transform.position.x, transform.position.y + addHeight, transform.position.z);
    }

    public void SetInteract(bool state)
    {
        isInteract = state;
    }

    public bool IsInteractable()
    {
        return isInteract;
    }
}
