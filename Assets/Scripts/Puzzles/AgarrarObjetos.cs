using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    [SerializeField] private Transform agarre;
    private GameObject objeto;
    [SerializeField] private float distancia = 1f;
    [SerializeField] private LayerMask objetos;
    private bool sosteniendo;

    private Librero posicionActual;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (sosteniendo)
            {
                SoltarObjeto();
            }
            else
            {
                AgarrarObjeto();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Librero librero = collision.GetComponent<Librero>();

        if (librero != null)
        {
            posicionActual = librero;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Librero librero = collision.GetComponent<Librero>();

        if (librero != null)
        {
            posicionActual = null;
        }
    }


    private void AgarrarObjeto()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, distancia, Vector2.zero, 0f, objetos);
        if (hit.collider != null)
        {
            objeto = hit.collider.gameObject;

            objeto.transform.SetParent(agarre);
            objeto.transform.localPosition = Vector3.zero;

            sosteniendo = true;
            Rigidbody2D rb = objeto.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.simulated = false;
            }
            SpriteRenderer srObjeto = objeto.GetComponent<SpriteRenderer>();
            SpriteRenderer srPlayer = GetComponent<SpriteRenderer>();

            if (srObjeto && srPlayer)
            {
                srObjeto.sortingOrder = srPlayer.sortingOrder + 1;
            }

        }

    }

    private void SoltarObjeto()
    {
        Rigidbody2D rb = objeto.GetComponent<Rigidbody2D>();

        if (posicionActual != null)
        {

            objeto.transform.SetParent(posicionActual.transform);
            objeto.transform.position = posicionActual.transform.position;

            if (rb)
            {
                rb.simulated = false;
            }
        }
        else
        {

            objeto.transform.SetParent(null);

            if (rb)
            {
                rb.simulated = true;

                Vector2 direccion = (objeto.transform.position - transform.position).normalized;
                rb.linearVelocity = direccion * 2f;
            }
        }

        objeto = null;
        sosteniendo = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distancia);
    }
}
