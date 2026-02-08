using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour
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

    [SerializeField] private float fuerzaEmpuje = 8f;
    [SerializeField] private float tiempoEmpuje = 0.2f;

    [HideInInspector]
    public bool puedeMoverse = true;
    private bool invulnerable;
    private void Start()
    {
        rbg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
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
        if (puedeMoverse)
        {
            if (theWorld)
            {
                Vector3 movimientoFrame = (Vector3)(direccion * movimiento * Time.unscaledDeltaTime);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, movimientoFrame.magnitude, LayerMask.GetMask("Wall"));

                if (!hit)
                {
                    transform.position += movimientoFrame;
                }
            }       
        }
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
    private void FixedUpdate()
    {
        if(!theWorld)
        {
            rbg.MovePosition(rbg.position + direccion * movimiento * Time.unscaledDeltaTime);
        }
    }
}

