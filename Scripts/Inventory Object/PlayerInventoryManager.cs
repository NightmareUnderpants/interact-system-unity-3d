using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    public static PlayerInventoryManager Instance { get; private set; }

    public IInventoryObject CurrentInventoryObject
    {
        get
        {
            return _listInventoryObjects[currentIndexInventoryObject];
        }
    }

    [SerializeField]
    private Transform _playerHand;

    private int currentIndexInventoryObject;
    private List<IInventoryObject> _listInventoryObjects = new List<IInventoryObject>();

    public event Action<IInventoryObject> OnItemAdded;
    public event Action<IInventoryObject> OnItemEquipped;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Создаем пустой объект только если инвентарь действительно пуст
        if (_listInventoryObjects.Count == 0)
        {
            CreateEmptyInventoryObject();
        }

        // Активируем первый предмет
        if (_listInventoryObjects.Count > 0)
        {
            SwitchObjectTo(0);
        }
    }

    public void AddObjectToInventory(IInventoryObject inventoryObject)
    {
        if (_listInventoryObjects.Contains(inventoryObject)) return;

        _listInventoryObjects.Add(inventoryObject);
        OnItemAdded?.Invoke(inventoryObject);

        SwitchObjectTo(_listInventoryObjects.Count - 1);
    }

    public void SwitchObjectTo(IInventoryObject inventoryObject)
    {
        int index = _listInventoryObjects.IndexOf(inventoryObject);
        if (index != -1)
        {
            SwitchObjectTo(index);
        }
    }

    public void SwitchObjectTo(int index)
    {
        if (_listInventoryObjects.Count == 0) return;

        if (index < 0) index = _listInventoryObjects.Count - 1;
        else if (index >= _listInventoryObjects.Count) index = 0;

        _listInventoryObjects[currentIndexInventoryObject].DisableObject();

        currentIndexInventoryObject = index;
        SetObjectInHand(_listInventoryObjects[currentIndexInventoryObject]);

        OnItemEquipped?.Invoke(_listInventoryObjects[currentIndexInventoryObject]);
    }

    public void SwitchObjectNext() => SwitchObjectTo(currentIndexInventoryObject + 1);
    public void SwitchObjectPrev() => SwitchObjectTo(currentIndexInventoryObject - 1);

    private void SetObjectInHand(IInventoryObject inventoryObject)
    {
        MonoBehaviour monoBehaviour = inventoryObject.GetMonoBehaviour();
        if (monoBehaviour == null)
        {
            Debug.LogError("Inventory object MonoBehaviour is null");
            return;
        }

        if (inventoryObject is EmptyInventoryObject)
        {
            inventoryObject.DisableObject();
            return;
        }

        inventoryObject.EnableObject();

        monoBehaviour.gameObject.transform.SetParent(_playerHand);
        monoBehaviour.gameObject.transform.localPosition = inventoryObject.GetOffsetPosition();
        monoBehaviour.gameObject.transform.localEulerAngles = inventoryObject.GetOffsetRotation();
    }

    private void CreateEmptyInventoryObject()
    {
        GameObject emptyGO = new GameObject("EmptyInventoryObject");
        emptyGO.transform.SetParent(transform);
        emptyGO.SetActive(false);

        EmptyInventoryObject emptyObj = emptyGO.AddComponent<EmptyInventoryObject>();
        _listInventoryObjects.Add(emptyObj);
    }
}