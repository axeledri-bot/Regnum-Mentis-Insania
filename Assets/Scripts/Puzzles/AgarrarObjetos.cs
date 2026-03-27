using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    public Libros libroEnMano;
    bool cercaPuerta;

    [SerializeField]private Transform agarre;
    [SerializeField] private LayerMask interactuableLayer;
    //[SerializeField]private Animator animator;

    private void Start()
    {

    }

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
        Collider2D hit = Physics2D.OverlapCircle(transform.position, .5f, interactuableLayer);

        //animator.SetBool("IsCarryng", true);

        Libros libro = null;
        Librero librero = null;

        if (hit)
        {
            libro = hit.GetComponent<Libros>();
            librero = hit.GetComponent<Librero>();
        }

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
                //animator.SetBool("IsCarryng", false);
                librero.ColocarLibro(libroEnMano);
                libroEnMano = null;
                return;
            }
            else if (libroEnMano == null && librero.libroActual != null)
            {
                libroEnMano = librero.QuitarLibro();
                //animator.SetBool("IsCarryng", true);


                Rigidbody2D rb = libroEnMano.GetComponent<Rigidbody2D>();
                if (rb) rb.simulated = false;

                libroEnMano.transform.SetParent(agarre);
                libroEnMano.transform.localPosition = Vector3.zero;

                return;
            }
        }

        if (libroEnMano != null)
        {
            Rigidbody2D rb = libroEnMano.GetComponent<Rigidbody2D>();

            libroEnMano.transform.SetParent(null);

            if (rb) rb.simulated = true;

            libroEnMano = null;
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

