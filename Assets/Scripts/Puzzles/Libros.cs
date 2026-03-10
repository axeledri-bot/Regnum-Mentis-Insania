using UnityEngine;

public class Libros : MonoBehaviour
{
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public string color;
}
