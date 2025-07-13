using System.Collections;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class TextViewer : MonoBehaviour
{
    private static TextViewer _instance;
    public static TextViewer Instance => _instance;

    public enum TextSize
    {
        Large,
        Small
    }
    private TextSize _textSize = TextSize.Large;

    [Header("Large")]
    [SerializeField]
    private CanvasGroup _containerLargeText;
    [SerializeField]
    private TextMeshProUGUI _textMeshLarge;

    [Header("Small")]
    [SerializeField]
    private CanvasGroup _containerSmallText;
    [SerializeField]
    private TextMeshProUGUI _textMeshSmall;

    private Sequence _activeSequence;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    public static void ViewLargeText(string text)
    {
        PlayerController.Instance.In_LockPlayerControls();

        Instance._textSize = TextSize.Large;
        Instance._textMeshLarge.text = text;
        Instance._containerLargeText.gameObject.SetActive(true);
    }

    public static void ViewSmallText(string text)
    {
        // Прерываем предыдущие анимации
        Instance._activeSequence?.Kill();

        Instance._textSize = TextSize.Small;
        Instance._textMeshSmall.text = text;
        Instance._containerSmallText.gameObject.SetActive(true);
        Instance._containerSmallText.alpha = 0;

        // Создаем новую последовательность
        Instance._activeSequence = DOTween.Sequence()
            .Append(Instance._containerSmallText.DOFade(1f, 0.5f))
            .AppendInterval(2f)
            .Append(Instance._containerSmallText.DOFade(0f, 0.5f))
            .OnComplete(() => {
                Instance._containerSmallText.gameObject.SetActive(false);
            });
    }

    // Для ручного закрытия (если нужно прервать автоматическое скрытие)
    public void TextHide()
    {
        switch (_textSize)
        {
            case TextSize.Large:
                _containerLargeText.gameObject.SetActive(false);
                PlayerController.Instance.Out_LockPlayerControls();
                break;
        }
    }
}