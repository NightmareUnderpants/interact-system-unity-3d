using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Scene_02_CreateCoffee : MonoBehaviour
{
    [Header("First Part")]
    public PlaceInteractObject coffeeMaker;
    public PlaceInteractObject faucet;
    public InteractObject coffeePot;
    public TapFaucetInteract tapFaucet;

    [Header("Second Part")]
    public PlaceInteractObject cupPlace;
    public InteractObject cupObject;

    [Space]
    public GameObject monster;
    public GameObject door;
    public GameObject lightGameObject;
    public GameObject trigger;
    public InteractCutscene interactCutscene;
    public ParticleSystem partical;

    [Space]
    [SerializeField]
    private float m_timeWaterFill = 6f;

    [Space]
    [SerializeField]
    private PropInteract m_washstand;

    private QuestSystem m_questSystem;
    private bool m_faceWashing = false;

    private void Start()
    {
        if (m_questSystem == null)
        {
            m_questSystem = FindObjectOfType<QuestSystem>();
        }
    }

    private void OnEnable()
    {
        faucet.OnObjectPlaced += WaitOfWater;
        coffeeMaker.OnObjectPlaced += MakeCoffee;
        coffeePot.OnObjectPicked += FaucetActivate;
    }

    private void FaucetActivate(string name)
    {
        if (name != "coffeePot") return;

        faucet.SetInteract(true);
    }

    private void OnDisable()
    {
        faucet.OnObjectPlaced -= WaitOfWater;
        coffeeMaker.OnObjectPlaced -= MakeCoffee;
    }


    public void WaitOfWater(string name)
    {
        if (name != "faucet") return;

        faucet.SetInteract(false);
        coffeePot.SetInteract(false);
        faucet.OnObjectPlaced -= WaitOfWater;

        tapFaucet.isInteractable = true;
        tapFaucet.onPourWater += FillWater;
    }

    private void FillWater() => StartCoroutine(FillWaterCoroutine());
    private IEnumerator FillWaterCoroutine()
    {
        AudioSource audioFaucet = faucet.GetComponent<AudioSource>();
        audioFaucet.Play();
        Destroy(faucet);

        yield return new WaitForSeconds(m_timeWaterFill);

        audioFaucet.Stop();
        coffeePot.SetInteract(true);
        coffeeMaker.gameObject.SetActive(true);
        Destroy(faucet);
    }

    public void MakeCoffee(string name)
    {
        if (name != "coffeePot") return;
        StartCoroutine(MakeCoffeeCoroutine());
    }
    private IEnumerator MakeCoffeeCoroutine()
    {
        // начинаем готовить кофе и включаем другой квест
        AudioSource audio = coffeeMaker.gameObject.GetComponent<AudioSource>();
        audio.Play();
        m_washstand.ChangeInteractState(true);
        Debug.Log("m_questSystem.StartNewQuest(2);");

        // ждем умывания
        while (!m_faceWashing)
        {
            yield return null;
        }

        coffeeMaker.SetInteract(false);
        m_washstand.ChangeInteractState(false);

        // добавляем слушателя и событие
        cupPlace.SetInteract(true);
        cupPlace.OnObjectPlaced += FillCup;
        Debug.Log("ЗАКОНЧИЛИ УМЫВАТЬСЯ");
    }



    public void FillCup(string name)
    {
        Debug.Log($"FillCup with id: {name}");
        if (name != "cup") return;
        cupPlace.OnObjectPlaced -= FillCup;

        Destroy(cupPlace.gameObject);
        Destroy(coffeePot.gameObject);
        cupObject.gameObject.SetActive(true);

        Debug.Log("m_questSystem.StartNewQuest(4);");
        interactCutscene.SetInteract(true);
        partical.Play();

        //monster.SetActive(true);
        //door.SetActive(false);
        //lightGameObject.SetActive(false);
        //trigger.SetActive(true);
    }

    public void ChangeCoffeeCreate()
    {
        m_faceWashing = true;
    }
}
