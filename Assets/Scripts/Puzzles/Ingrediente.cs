using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public string nombreIngrediente;
    private bool jugadorCerca = false;

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
        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
   
}
