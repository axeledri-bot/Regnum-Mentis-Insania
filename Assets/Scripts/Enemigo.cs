using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 3f;
    public float radius = 3f;
    public LayerMask whatIsPlayer;

    private Rigidbody2D rb;
    private Vector3 objetivo;
    private bool moving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objetivo = transform.position;
    }

    void FixedUpdate()
    {
        if (!moving)
        {
            Vector3 targetPos = GetTargetPosition();
            if (targetPos != transform.position)
            {
                objetivo = targetPos;
                moving = true;
            }
        }

        if (moving)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, objetivo, velocidad * Time.fixedDeltaTime));

            if (Vector3.Distance(rb.position, objetivo) < 0.01f)
            {
                rb.position = objetivo;
                moving = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PerderVida();
        }
    }
    private void OnDrawGizmosSelected()
    { 
        Gizmos.color = Color.red; Gizmos.DrawWireSphere(transform.position, radius); 
    }

Vector3 GetTargetPosition()
    {
        Collider2D detect = Physics2D.OverlapCircle(rb.position, radius, whatIsPlayer);
        Vector3 destino = detect ? detect.transform.position : transform.position;
        Vector3 delta = destino - transform.position;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            return transform.position + new Vector3(Mathf.Sign(delta.x), 0, 0);
        }
        else if (Mathf.Abs(delta.y) > 0)
        {
            return transform.position + new Vector3(0, Mathf.Sign(delta.y), 0);
        }

        return transform.position;
    }
}



