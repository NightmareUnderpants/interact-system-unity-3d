using System;
using System.Collections;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;

public class ToiletInteract : MonoBehaviour, IInteractable
{
    public ScreenFade screenFade;
    public PlayerController playerController;
    public GameObject monster;
    public GameObject triggerMonster;
    public QuestSystem questSystem;

    [SerializeField]
    private bool _isInteractable;

    public void Interact(Transform interactorTransform)
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        playerController.LockPlayerController();
        playerController.LockPlayerRotation();

        screenFade.CutsceneTransitionSecondIn(2f);

        yield return new WaitForSeconds(2f);

        monster.SetActive(true);
        triggerMonster.SetActive(true);
        QuestSystem.Instance.CompleteQuest(5);
        Debug.Log("QuestSystem.Instance.CompleteQuest(5);");
        screenFade.CutsceneTransitionSecondOut(2f);

        playerController.UnLockPlayerController();
        playerController.UnLockPlayerRotation();
    }
    
    public void SetInteract(bool state)
    {
        _isInteractable = state;    
    }

    public Vector3 GetInteractVector3()
    {
        return transform.position;
    }

    public bool IsInteractable()
    {
        return _isInteractable;
    }
}
