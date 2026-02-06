using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    [SerializeField] private RectTransform panelTransform;

    private CanvasGroup _canvasGroup;

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        _canvasGroup.alpha = 0;
        panelTransform.localScale = Vector3.zero;

        _canvasGroup.DOFade(1, 0.2f).SetEase(Ease.Linear);
        panelTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    public void Hide()
    {
        _canvasGroup.DOFade(0, 0.3f).SetEase(Ease.Linear);
        panelTransform.DOScale(0, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
