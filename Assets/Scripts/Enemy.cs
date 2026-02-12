
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Referencias")]
    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsPlayer;

    [Header("Patrullaje")]
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float tiempoEspera;
    private int puntoActual;
    private bool esperando;

    [Header("Aturdido")]
    [SerializeField] private float tiempoAturdido;
    [HideInInspector] public bool aturdido;

    [Header("Comportamiento")]
    [SerializeField] private bool usarPatrullaje = true;

    private bool detect;
    private bool flip = true;

    private enum Estado { Idle, Patrulla, Persecucion, Aturdido }
    private Estado estadoActual;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        estadoActual = Estado.Patrulla;
    }

    private void Update()
    {
        detect = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);

        if (aturdido)
        {
            estadoActual = Estado.Aturdido;
        }
        else if (detect)
        {
            estadoActual = Estado.Persecucion;
        }
        else if (usarPatrullaje)
        {
            estadoActual = Estado.Patrulla;
        }
        else
        {
            estadoActual = Estado.Idle;
        }
    }

    private void FixedUpdate()
    {
        switch (estadoActual)
        {
            case Estado.Patrulla:
                Patrullar();
                break;

            case Estado.Persecucion:
                Perseguir();
                break;

            case Estado.Aturdido:
                rb.linearVelocity = Vector2.zero;
                animator.SetBool("Moving", false);
                break;
            case Estado.Idle:
                rb.linearVelocity = Vector2.zero;
                animator.SetBool("Moving", false);
                break;
        }
    }

   

    private void Patrullar()
    {
        if (puntos.Length == 0) return;

        if (Vector2.Distance(rb.position, puntos[puntoActual].position) > 0.1f)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position,
                puntos[puntoActual].position,
                velocidad * Time.deltaTime);

            rb.MovePosition(newPos);
            animator.SetBool("Moving", true);

            Flip(puntos[puntoActual].position.x > transform.position.x);
        }
        else if (!esperando)
        {
            StartCoroutine(Esperar());
        }
    }

    IEnumerator Esperar()
    {
        esperando = true;
        animator.SetBool("Moving", false);

        yield return new WaitForSeconds(tiempoEspera);

        puntoActual++;
        if (puntoActual >= puntos.Length)
            puntoActual = 0;

        esperando = false;
    }



    private void Perseguir()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        Vector2 newPos = Vector2.MoveTowards(rb.position,
            player.position,
            velocidad * Time.deltaTime);

        rb.MovePosition(newPos);

        animator.SetBool("Moving", true);

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            animator.SetFloat("MovX", 1);
            animator.SetFloat("MovY", 0);
            Flip(direction.x > 0);
        }
        else
        {
            animator.SetFloat("MovX", 0);
            animator.SetFloat("MovY", Mathf.Sign(direction.y));
        }
    }

    public void Aturdido()
    {
        if (!aturdido)
            StartCoroutine(Aturdir());
    }

    IEnumerator Aturdir()
    {
        aturdido = true;
        yield return new WaitForSeconds(tiempoAturdido);
        aturdido = false;
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject
                .GetComponent<Player>()
                .RecibirDaño(transform.position);

            CameraShake.instance.Shake(0.6f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

