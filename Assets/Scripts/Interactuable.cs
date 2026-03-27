using UnityEngine;

public class Interactuable : MonoBehaviour
{

[SerializeField]private SpriteRenderer sRenderer;

    [SerializeField] private Sprite original;
    [SerializeField] private Sprite interactuable;
    void Start()
    {
        sRenderer.GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sRenderer.sprite = interactuable;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sRenderer.sprite = original;
        }
    }
}
