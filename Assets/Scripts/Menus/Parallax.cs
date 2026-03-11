using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float intensidad = 10f;

    Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
        Vector2 mouse = Input.mousePosition;

        float x = (mouse.x / Screen.width - 0.5f) * intensidad;
        float y = (mouse.y / Screen.height - 0.5f) * intensidad;

        transform.localPosition = posicionInicial + new Vector3(x, y, 0);
    }
}
