using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    public Libros libroEnMano;
    bool cercaPuerta;

    [SerializeField] private Transform agarre;
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
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, .5f, interactuableLayer);

        //animator.SetBool("IsCarryng", true);

        Libros libro = null;
        Librero librero = null;

        foreach (Collider2D col in hit)
        {
            libro = col.GetComponent<Libros>();
            AudioManager.instance.Play("Agarrar");
            if (libro != null)
                break;
        }

        if (libro == null)
        {
            foreach (Collider2D col in hit)
            {
                librero = col.GetComponent<Librero>();
                if (librero != null)
                    break;
            }
        }
        //if (hit)
        //{
        //    libro = hit.GetComponent<Libros>();
        //    librero = hit.GetComponent<Librero>();

        //}

        if (libro != null && libroEnMano == null)
        {
            libroEnMano = libro;


            Rigidbody2D rb = libro.GetComponent<Rigidbody2D>();
            if (rb) rb.simulated = false;

            SpriteRenderer sr = libro.GetComponent<SpriteRenderer>();
            if (sr != null)
            { sr.enabled = false; }

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

                SpriteRenderer sr = libroEnMano.GetComponentInChildren<SpriteRenderer>();
                if (sr != null) sr.enabled = true;

                libroEnMano = null;
                return;
            }
            else if (libroEnMano == null && librero.libroActual != null)
            {
                libroEnMano = librero.QuitarLibro();
                //animator.SetBool("IsCarryng", true);


                Rigidbody2D rb = libroEnMano.GetComponent<Rigidbody2D>();
                if (rb) rb.simulated = false;

                SpriteRenderer sr = libroEnMano.GetComponent<SpriteRenderer>();
                if (sr != null) sr.enabled = false;

                libroEnMano.transform.SetParent(agarre);
                libroEnMano.transform.localPosition = Vector3.zero;

                return;
            }
        }

        if (libroEnMano != null)
        {
            Rigidbody2D rb = libroEnMano.GetComponent<Rigidbody2D>();
            if (rb) rb.simulated = true;

            SpriteRenderer sr = libroEnMano.GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = true;
            libroEnMano.transform.SetParent(null);

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}

