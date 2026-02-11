
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] public float velocidad;
    //[SerializeField] private float minDistance;
    [SerializeField] private float radius;
    private bool detect;
    private Rigidbody2D rb;
    private bool flip = true;

    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        detect = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);

    }
    private void FixedUpdate()
    {
        if (detect)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 newPos = Vector2.MoveTowards(rb.position, player.position, velocidad * Time.deltaTime);
            rb.MovePosition(newPos);

            animator.SetBool("Moving", true);
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                animator.SetFloat("MovX", 1);
                animator.SetFloat("MovY", 0);
                bool playerRight = direction.x > 0;
                Flip(playerRight);
            }
            else
            {
                animator.SetFloat("MovX", 0);
                animator.SetFloat("MovY", Mathf.Sign(direction.y));
            }

         
        }
    }
    private void Flip(bool playerRight)
    {
        if ((flip && !playerRight) || (!flip && playerRight))
        {
            flip = !flip;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().RecibirDaño(transform.position);
            CameraShake.instance.Shake(0.6f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}

