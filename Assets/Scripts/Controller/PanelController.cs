using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    // ÆË¾÷ ÆÐ³ÎÀÇ RectTransform ÂüÁ¶
    [SerializeField] private RectTransform panelTransform;

    public delegate void PanelControllerHideDelegate();

    private CanvasGroup _canvasGroup;

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    // ÆË¾÷ Ç¥½Ã
    public void Show()
    {
        Debug.Log("Show panel");

        // ÆÐ³Î ÀÏ´Ü ¼û±â±â
        _canvasGroup.alpha = 0;
        panelTransform.localScale = Vector3.zero;

        _canvasGroup.DOFade(1, 0.3f).SetEase(Ease.Linear);
        panelTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    // ÆË¾÷ ¼û±â±â
    public void Hide(PanelControllerHideDelegate onComplete = null)
    {
        _canvasGroup.DOFade(0, 0.3f).SetEase(Ease.Linear);
        panelTransform.DOScale(0, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            onComplete?.Invoke();
            Destroy(gameObject);
        });
    }
}