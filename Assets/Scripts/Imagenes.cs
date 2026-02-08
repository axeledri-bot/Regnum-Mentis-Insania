using UnityEngine;
using UnityEngine.EventSystems;

public class Imagenes : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public GameObject Imagen;
    public GameObject Imagen2;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Imagen.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Imagen.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Imagen2.SetActive(true);
    }
}
