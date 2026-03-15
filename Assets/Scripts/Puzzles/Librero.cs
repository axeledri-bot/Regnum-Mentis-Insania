using UnityEngine;

public class Librero : MonoBehaviour
{
    public Libros libroActual;

    [SerializeField] SpriteRenderer spriteRenderer;


    public PuzzleBiblioteca puzzle;
    
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void ColocarLibro(Libros libro)
    {
        if (libroActual != null) return;

        libroActual = libro;

        libro.gameObject.SetActive(false);

        CambiarSprite(libro.color);

        puzzle.Verificar();
    }
    public Libros QuitarLibro()
    {
        if (libroActual == null) return null;

        animator.SetTrigger("Quitar");

        Libros libro = libroActual;

        libroActual = null;

        //spriteRenderer.sprite = vacio;

        libro.gameObject.SetActive(true);

        return libro;
    }
    void CambiarSprite(string color)
    {
        switch (color)
        {
            case "Rojo":
                animator.SetTrigger("Rojo");
                break;
            case "Azul":
                animator.SetTrigger("Azul");
                break;
            case "Blanco":
                animator.SetTrigger("Blanco");
                break;
            case "Amarillo":
                animator.SetTrigger("Amarillo");
                break;
        }
        //switch (color)
        //{
        //    case "Rojo": spriteRenderer.sprite = rojo; break;
        //    case "Azul": spriteRenderer.sprite = azul; break;
        //    case "Blanco": spriteRenderer.sprite = blanco; break;
        //    case "Amarillo": spriteRenderer.sprite = amarillo; break;
        //}
    }
}

