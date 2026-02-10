using UnityEngine;
using UnityEngine.EventSystems;

public class Base : MonoBehaviour, IDropHandler
{ 

    private void Start()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;    
        }

    }
    public void Cerrar()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
