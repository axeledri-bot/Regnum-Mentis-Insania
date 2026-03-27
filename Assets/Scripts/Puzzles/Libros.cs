using UnityEngine;

public class Libros : MonoBehaviour
{
    public SpriteRenderer sr;

    [SerializeField] private Sprite original;
    [SerializeField] private Sprite interactuable;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public string color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sr.sprite = interactuable;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sr.sprite = original;
        }
    }
}
