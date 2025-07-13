using UnityEngine;

public class PlaceWithViewTextInteractObject : PlaceInteractObject
{
    [SerializeField, TextArea]
    private string _textString;

    [SerializeField]
    private TextViewer.TextSize _textSize = TextViewer.TextSize.Small;

    public override void Interact(Transform interactorTransform)
    {
        base.Interact(interactorTransform);

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
}
