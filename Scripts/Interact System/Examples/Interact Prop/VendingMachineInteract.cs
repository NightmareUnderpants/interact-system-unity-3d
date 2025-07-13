using UnityEngine;
using System.Collections;

public class VendingMachineInteract : MonoBehaviour, IInteractable
{
    public Transform alexanderTransform;
    public Transform camPlayerTransform;
    public Transform spawnCanTransform;
    public GameObject canPrefab;
    public AudioClip canSpawnSound;
    
    [Space]
    public NPCInteractive interactableNPC;

    [Space]
    [SerializeField]
    private bool _isInteractable;
    [SerializeField]
    private Vector3 _interactIconOffset;

    private Animator _animator;
    private GameObject can;

    private void Start()
    {
        _animator = GetComponent<Animator>(); 
    }

    public void Interact(Transform interactorTransform)
    {
        _isInteractable = false;
        //AnimShakeVendingMachine();
        ChangeAlexanderPosition();
        StartCoroutine(SpawnCan());
    }

    private void ChangeAlexanderPosition()
    {
        Vector3 pos = camPlayerTransform.position - camPlayerTransform.forward * 1.5f;
        alexanderTransform.position = new Vector3(pos.x, alexanderTransform.position.y, pos.z);
    }

    private void AnimShakeVendingMachine()
    {
        _animator.Play("Scene_01_vending_machine");
    }

    private IEnumerator SpawnCan()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = canSpawnSound;
        audioSource.Play();

        yield return new WaitForSeconds(11f);
        
        can = Instantiate(canPrefab, spawnCanTransform.position, spawnCanTransform.rotation);
        can.transform.eulerAngles += new Vector3(0f, 90f, 90f);

        Rigidbody canRb = can.GetComponent<Rigidbody>();
        canRb.AddForce(
            spawnCanTransform.TransformDirection(spawnCanTransform.forward),
            ForceMode.Impulse
        );

        InteractObject canInteractObject = can.GetComponent<InteractObject>();
        canInteractObject.SetInteract(true);
        if (canInteractObject == null)
            Debug.LogError("ERROR");
        interactableNPC.interactObjectList.Add(canInteractObject);
    }

    public Vector3 GetInteractVector3()
    {
        return transform.position + _interactIconOffset;
    }

    public bool IsInteractable()
    {
        return _isInteractable;
    }
}
