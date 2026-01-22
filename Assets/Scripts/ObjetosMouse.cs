using UnityEngine;

public class ObjetosMouse : MonoBehaviour
{
    //public bool mouseWorks = false;

    private Vector3 screenPoint, offset;

    void OnMouseDown()
    {
        //mouseWorks = true;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        transform.position = currentPosition;
    }

    //private void OnMouseUp()
    //{
    //    //mouseWorks = false;
    //}
}
