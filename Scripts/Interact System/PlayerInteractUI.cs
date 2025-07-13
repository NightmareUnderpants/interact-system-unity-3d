using System;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField]
    private GameObject containerGameObject;
    private PlayerInteractManager playerInteract;
    [SerializeField]
    private TextMeshProUGUI interactTextMeshProUGUI;
    private DialogueSystem dialogueSystem;
    [SerializeField]
    public GameObject canvasPrefab;
    [SerializeField]
    private Transform canvasContainer;

    private InteractIconUI interactIconUI;

    private void Awake()
    {
        playerInteract = FindAnyObjectByType<PlayerInteractManager>();
        dialogueSystem = FindAnyObjectByType<DialogueSystem>();
        interactIconUI = FindAnyObjectByType<InteractIconUI>();
    }

    private void Update()
    {
        if (playerInteract.GetInteractable() != null)
        {
            interactIconUI.SetIconInteractive();
        }
        else interactIconUI.IconInteractiveOff();
    }
}
