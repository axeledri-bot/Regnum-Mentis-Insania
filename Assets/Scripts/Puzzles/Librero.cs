using UnityEngine;

public class Librero : MonoBehaviour
{
    public Libros libroActual;

    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Sprite vacio;
    [SerializeField] Sprite rojo;
    [SerializeField] Sprite azul;
    [SerializeField] Sprite blanco;
    [SerializeField] Sprite amarillo;

    public PuzzleBiblioteca puzzle;
    
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void ColocarLibro(Libros libro)
    {
        if (libroActual != null) return;

        animator.SetBool("Vacio", false);

        libroActual = libro;

        libro.gameObject.SetActive(false);

        CambiarSprite(libro.color);

        puzzle.Verificar();
    }
    public Libros QuitarLibro()
    {
        if (libroActual == null) return null;

        animator.SetBool("Vacio", true);

        Libros libro = libroActual;

        libroActual = null;

        spriteRenderer.sprite = vacio;

        libro.gameObject.SetActive(true);

        return libro;
    }
    void CambiarSprite(string color)
    {
        switch (color)
        {
            case "Rojo":
                animator.SetBool("Rojo", true);
                break;
            case "Azul":
                animator.SetBool("Azul", true);
                break;
            case "Blanco":
                animator.SetBool("Blanco", true);
                break;
            case "Amarillo":
                animator.SetBool("Amarillo", true);
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

