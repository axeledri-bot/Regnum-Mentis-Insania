using Unity.VisualScripting;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public GameObject objeto;
    [SerializeField] private bool destruir;
    public Alquimia alquimia;

    [SerializeField] private int idNota;

    [SerializeField] private string sonidoAbrir = "Notas";
    [SerializeField] private string sonidoCerrar = "Notas";

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spriteOriginal;
    [SerializeField] Sprite interactuable;

    private bool adentro;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(adentro && Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }
    public void Interactuar()
    {

        if (alquimia != null)
        {
            alquimia.AbrirPuzzle();
            return;
        }

        if (objeto != null)
        {
            objeto.SetActive(true);

            Notas notas = objeto.GetComponent<Notas>();
            if (notas != null)
            {
                notas.SetSonidos(sonidoAbrir, sonidoCerrar);
            }
            GameManager.instance.GuardarNota(idNota);
        }

        AudioManager.instance.Play(sonidoAbrir);
        GameManager.instance.ActivarUI();

        if (destruir)
        {
            Destroy(this.gameObject);
        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            adentro = true;
            spriteRenderer.sprite = interactuable;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            adentro = false;
            spriteRenderer.sprite = spriteOriginal;
        }
    }
}
