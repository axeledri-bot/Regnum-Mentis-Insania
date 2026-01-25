using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 5f;
    public float radius = 2f;
    public LayerMask whatIsPlayer;
    public Transform[] puntos;
    public float stopDistance = 0.1f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Transform player;
    private Vector2 direccion;
    private int puntoActual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Collider2D detect = Physics2D.OverlapCircle(rb.position, radius, whatIsPlayer);

        Vector2 objetivo;

        if (detect != null)
        {
            player = detect.transform;
            objetivo = player.position;
        }
        else
        {
            objetivo = puntos[puntoActual].position;
        }


        Vector2 delta = objetivo - rb.position;

        
        if (delta.magnitude < stopDistance)
        {
            direccion = Vector2.zero;
            return;
        }

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            direccion = new Vector2(Mathf.Sign(delta.x), 0);
        }
        else
        {
            direccion = new Vector2(0, Mathf.Sign(delta.y));
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}


