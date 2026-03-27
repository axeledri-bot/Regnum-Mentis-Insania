using UnityEngine;

public class Manta : MonoBehaviour
{

    [SerializeField] private Sprite camaNormal;
    [SerializeField] private Sprite camaInteractuable;
    [SerializeField] private Sprite camaVacia;

    [SerializeField]private SpriteRenderer spriteRenderer;
    private bool recogida;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (!recogida)
            {
                spriteRenderer.sprite = camaInteractuable;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !recogida)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                RecojerManta.tieneManta = true;
                spriteRenderer.sprite = camaVacia;

                AudioManager.instance.Play("Manta 2");
                recogida = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (!recogida)
            {
                spriteRenderer.sprite = camaNormal;
            }
        }
    }
}
