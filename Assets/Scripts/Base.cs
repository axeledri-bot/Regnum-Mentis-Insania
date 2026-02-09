using UnityEngine;
using UnityEngine.EventSystems;

public class Base : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;    
        }
      
    }
}
