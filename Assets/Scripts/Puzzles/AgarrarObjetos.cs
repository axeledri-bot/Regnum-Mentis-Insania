using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    public Libros libroEnMano;
    bool cercaPuerta;

    [SerializeField]private Transform agarre;
    [SerializeField] private LayerMask interactuableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cercaPuerta) return; 

            InteractuarLibros();
        }
        
    }
    void InteractuarLibros()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1f, interactuableLayer);

        if (!hit) return;

        Libros libro = hit.GetComponent<Libros>();
        Librero librero = hit.GetComponent<Librero>();
        Debug.Log(hit.name);
        if (libro != null && libroEnMano == null)
        {
            libroEnMano = libro;
            Rigidbody2D rb = libro.GetComponent<Rigidbody2D>();
            if (rb) rb.simulated = false;

            libro.transform.SetParent(agarre);
            libro.transform.localPosition = Vector3.zero;
            return;
        }

        if (librero != null)
        {
            if (libroEnMano != null && librero.libroActual == null)
            {
                librero.ColocarLibro(libroEnMano);
                libroEnMano = null;
            }
            else if (libroEnMano == null && librero.libroActual != null)
            {
                libroEnMano = librero.QuitarLibro();
                Rigidbody2D rb = libroEnMano.GetComponent<Rigidbody2D>();
                if (rb) rb.simulated = false;
                libroEnMano.transform.SetParent(agarre);
                libroEnMano.transform.localPosition = Vector3.zero;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transiciones>() != null)
        {
            cercaPuerta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Transiciones>() != null)
        {
            cercaPuerta = false;
        }
    }
}

