using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFaucetInteract : MonoBehaviour, IInteractable
{
    public bool isInteractable = false;
    public bool isCanPourWater = false;

    [SerializeField]
    private string textView;

    public event Action onPourWater;

    public void Interact(Transform interactorTransform)
    {
        if (isCanPourWater)
        {
            onPourWater?.Invoke();
        }
        else
        {
            TextViewer.ViewSmallText(textView);
        }
    }

    public Vector3 GetInteractVector3()
    {
        return transform.position;
    }

    public bool IsInteractable()
    {
        return isInteractable;
    }
}
