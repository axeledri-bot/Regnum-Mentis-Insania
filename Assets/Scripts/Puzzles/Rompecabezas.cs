using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RompecabezasBase : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas Canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public int idPieza;
    private Vector2 posicionInicial;

    public PuzzleManager puzzle;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        posicionInicial = rectTransform.anchoredPosition;
    }

    public void Resetear()
    {
        rectTransform.anchoredPosition = posicionInicial;
        enabled = true;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }   
}
