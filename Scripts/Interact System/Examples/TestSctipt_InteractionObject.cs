using UnityEngine;

public class TestSctipt_InteractionObject : MonoBehaviour
{
    public InteractObject cylinder1;
    public InteractObject cylinder2;
    public PlaceInteractObject placeForCylinder1;
    public PlaceInteractObject placeForCylinder2;
    public PlaceInteractObject placeForAnyObject;
    public PlaceInteractObject placeForPlaceAfterCylinder;

    private bool cylinder1Placed = false;

    private void Start()
    {
        // test Pick Up Object
        cylinder1.OnObjectPicked += Test_OnObjectPicked;
        cylinder2.OnObjectPicked += Test_OnObjectPicked;

        // test Place Object
        placeForCylinder1.OnObjectPlaced += Test_OnObjectPlaced;
        placeForCylinder2.OnObjectPlaced += Test_OnObjectPlaced;

        // test interact with PLACED object
        placeForCylinder1.OnObjectInteract += Test_OnObjectInteract;
        cylinder1.OnObjectInteract += Test_OnObjectInteract;

        // test placeAnyObject
        placeForAnyObject.OnObjectPlaced += Test_PlaceAnyObject;

        // test place after place another object
        placeForPlaceAfterCylinder.OnObjectPlaced += Test_OnObjectPlaced_PlaceAfterCylinder;
        placeForCylinder1.OnObjectPlaced += Test_OnObjectPlaced_PlaceForCylinder1;
    }

    private void Test_OnObjectPlaced_PlaceAfterCylinder(string obj)
    {
        if (obj != "placeAfterCylinder" && !cylinder1Placed) return;

        Debug.Log($"{obj} has been placed after placed cylinder1");
    }

    private void Test_OnObjectPlaced_PlaceForCylinder1(string obj)
    {
        if (obj != "place1") return;

        cylinder1Placed = true;
        placeForPlaceAfterCylinder.interactObjectList.Add(cylinder2);
        Debug.Log($"{obj} has been placed");
    }

    private void Test_PlaceAnyObject(string obj)
    {
        if (obj != "anyPlaceObject") return;

        Debug.Log($"{obj} has been placed at ANY PLACE OBJECT");
    }

    private void Test_OnObjectInteract(string obj)
    {
        if (obj != "place1" && obj != "cylinder1") return;

        Debug.Log($"{obj} has been ObjectInteracted in place!");
    }

    private void Test_OnObjectPlaced(string obj)
    {
        Debug.Log($"{obj} is that place1 or place1?");

        if (obj != "place1" && obj != "place2") return;

        Debug.Log($"{obj} has been placed");
    }

    private void Test_OnObjectPicked(string obj)
    {
        if (obj != "cylinder1" && obj != "cylinder2") return;

        Debug.Log($"{obj} has been picked");
    }
}
