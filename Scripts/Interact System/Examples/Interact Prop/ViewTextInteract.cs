using System.Collections;
using UnityEngine;

public class ViewTextInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool _isInteractable = true;

    [SerializeField, TextArea]
    private string _textString;

    [SerializeField]
    private TextViewer.TextSize _textSize = TextViewer.TextSize.Small;

    public void Interact(Transform interactorTransform)
    {
        switch (_textSize)
        {
            case TextViewer.TextSize.Large:
                TextViewer.ViewLargeText(_textString);
                break;
            case TextViewer.TextSize.Small:
                TextViewer.ViewSmallText(_textString);
                break;
            default:
                break;
        }
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
