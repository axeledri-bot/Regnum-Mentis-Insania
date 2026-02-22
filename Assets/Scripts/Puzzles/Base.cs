using UnityEngine;
using UnityEngine.EventSystems;

public class Base : MonoBehaviour, IDropHandler
{
    public int idCorrecto;
    private bool ocupada;

    public PuzzleManager puzzle;

    public void OnDrop(PointerEventData eventData)
    {
        if (ocupada) return;

        RompecabezasBase pieza = eventData.pointerDrag.GetComponent<RompecabezasBase>();
        if (pieza == null) return;

        pieza.GetComponent<RectTransform>().anchoredPosition =GetComponent<RectTransform>().anchoredPosition;

        pieza.enabled = false;
        ocupada = true;

        puzzle.RegistrarColocacion(pieza, this);
    }
    public void ResetearBase()
    {
        ocupada = false;
    }
  
}
