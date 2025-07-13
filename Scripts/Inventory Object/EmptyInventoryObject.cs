using UnityEngine;

public class EmptyInventoryObject : MonoBehaviour, IInventoryObject
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Interact() { }
    public void DisableObject() { }
    public void EnableObject() { }
    public Vector3 GetOffsetPosition() => Vector3.zero;
    public Vector3 GetOffsetRotation() => Vector3.zero;
    public MonoBehaviour GetMonoBehaviour() => this;
}
