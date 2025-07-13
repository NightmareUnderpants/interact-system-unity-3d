using UnityEngine;

public interface IInventoryObject
{
    public void Interact();
    public void DisableObject();
    public void EnableObject();
    public Vector3 GetOffsetPosition();
    public Vector3 GetOffsetRotation();
    public MonoBehaviour GetMonoBehaviour();
}
