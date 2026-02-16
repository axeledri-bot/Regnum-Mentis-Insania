using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movimiento = 5f;
    private Vector2 direccion;
    private Rigidbody2D rbg;
    private float direccionX;
    private float direccionY;
    private Animator anim;
    private SpriteRenderer sprite;


    [HideInInspector]
    public bool theWorld;
    [SerializeField] private TrailRenderer trail;

    [SerializeField] private float fuerzaEmpuje = 8f;
    [SerializeField] private float tiempoEmpuje = 0.2f;

    [HideInInspector]
    public bool puedeMoverse = true;
    private bool invulnerable;

    [SerializeField] private float tiempoParpadeo = 0.5f;
    [SerializeField] private float intervaloParpadeo = 0.1f;
    private Color colorOriginal;

    private void Start()
    {
        rbg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        colorOriginal = sprite.color;
    }

    private void Update()
    {
        if (!puedeMoverse)
        {
            direccion = Vector2.zero;
            anim.SetBool("Moving", false);
            return;
        }

        direccionX = Input.GetAxisRaw("Horizontal");
        direccionY = Input.GetAxisRaw("Vertical");
        if (direccionX != 0)
        {
            direccion = new Vector2(direccionX, 0);
        }
        else if (direccionY != 0)
        {

            direccion = new Vector2(0, direccionY);
        }
        else
        {
            direccion = Vector2.zero;
        }
        anim.SetBool("Moving", direccion != Vector2.zero);
        if (direccion != Vector2.zero)
        {
            if (direccion.x != 0)
            {
                anim.SetFloat("MovX", 1);
                anim.SetFloat("MovY", 0);
                sprite.flipX = direccion.x < 0;
            }
            else if (direccion.y != 0)
            {
                anim.SetFloat("MovX", 0);
                anim.SetFloat("MovY", direccion.y);
            }
        }
        if (theWorld && puedeMoverse)
        {

            float delta = Time.unscaledDeltaTime;

            Vector2 movimientoFrame = direccion * movimiento * delta;

            RaycastHit2D hit = Physics2D.Raycast( transform.position,direccion,movimientoFrame.magnitude,LayerMask.GetMask("Wall"));

            if (!hit)
            {
                transform.position += (Vector3)movimientoFrame;
            }
        }
        if (theWorld && direccion != Vector2.zero)
        {
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
    }
    private void FixedUpdate()
    {
        if (!puedeMoverse || theWorld) return;

        float delta = Time.deltaTime;

        Vector2 movimientoFrame = direccion * movimiento * delta;
        Vector2 nuevaPos = rbg.position + movimientoFrame;

        RaycastHit2D hit = Physics2D.Raycast(
            rbg.position,
            direccion,
            movimientoFrame.magnitude,
            LayerMask.GetMask("Wall")
        );

        if (!hit)
        {
            rbg.MovePosition(nuevaPos);

        }
    }
    public void ActivarModoTiempoDetenido()
    {
        rbg.simulated = false;
    }

    public void DesactivarModoTiempoDetenido()
    {
        rbg.simulated = true;
    }
    public void RecibirDaño(Vector2 origen)
    {
        if (invulnerable) return;

        invulnerable = true;
        GameManager.instance.PerderVida();

        Vector2 direccion = (Vector2)transform.position - origen;
        direccion.Normalize();

        StartCoroutine(Empuje(direccion));
    }
    IEnumerator Empuje(Vector2 direccion)
    {
        puedeMoverse = false;

        StartCoroutine(Parpadeo());

        float tiempo = 0f;
        Vector2 inicio = transform.position;
        Vector2 destino = inicio + direccion * fuerzaEmpuje;

        while (tiempo < tiempoEmpuje)
        {
            tiempo += Time.unscaledDeltaTime;
            transform.position = Vector2.Lerp(inicio, destino, tiempo / tiempoEmpuje);
            yield return null;
        }
        puedeMoverse = true;

        yield return new WaitForSecondsRealtime(0.5f);
        invulnerable = false;
    }
    IEnumerator Parpadeo()
    {
        float tiempo = 0f;

        while (tiempo < tiempoParpadeo)
        {
            sprite.color = Color.red;

            yield return new WaitForSecondsRealtime(intervaloParpadeo);

            sprite.color = colorOriginal;

            yield return new WaitForSecondsRealtime(intervaloParpadeo);

            tiempo += intervaloParpadeo * 2;
        }

        sprite.color = colorOriginal;
    }

    //IEnumerator Parpadeo()
    //{
    //    float tiempo = 0f;

    //    while (tiempo < tiempoParpadeo)
    //    {
    //        sprite.enabled = !sprite.enabled;

    //        yield return new WaitForSecondsRealtime(intervaloParpadeo);
    //        tiempo += intervaloParpadeo;
    //    }

    //    sprite.enabled = true;
    //}
}

