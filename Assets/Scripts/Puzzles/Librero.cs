using UnityEngine;

public class Librero : MonoBehaviour
{
    public Libros libroColocado;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Libros libro = collision.GetComponent<Libros>();
        if(libro != null)
        {
            libroColocado = libro;

            collision.transform.position = transform.position;
            collision.transform.SetParent(transform);

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if(rb)
            {
                rb.simulated = false;
            }
        }
    }
}
