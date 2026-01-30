using UnityEngine;

public class InteraccionJugador : MonoBehaviour
{
    private Objeto interactuar; 

    void Update()
    {
        if (interactuar != null && Input.GetKeyDown(KeyCode.E))
        {
            interactuar.Interactuar();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Objeto obj = collision.GetComponent<Objeto>();
        if (obj != null)
        {
            interactuar = obj;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Objeto obj = collision.GetComponent<Objeto>();
        if (obj != null && obj == interactuar)
        {
            interactuar = null;
        }
    }
}




