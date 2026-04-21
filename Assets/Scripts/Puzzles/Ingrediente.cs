using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public string nombreIngrediente;
    private bool jugadorCerca = false;


    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite original;
    [SerializeField] private Sprite interactuable;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Recoger();
        }
    }

    private void Recoger()
    {
        InventarioJugador.instance.AgregarIngrediente(nombreIngrediente);

        AudioManager.instance.Play("Agarrar");

        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = interactuable;
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = original;
            jugadorCerca = false;
        }
    }

}
