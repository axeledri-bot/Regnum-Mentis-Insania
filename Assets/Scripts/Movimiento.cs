using System.Collections;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float movimiento = 5f;
    private Vector2 direccion;
    private Rigidbody2D rbg;
    private float direccionX;
    private float direccionY;
    [SerializeField]private Animator anim;
    [SerializeField]private SpriteRenderer sprite;

    public bool puedeMoverse = true;
    private void Start()
    {
        rbg = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
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
            if(direccion.x != 0)
            {
                anim.SetFloat("MovX", 1);
                anim.SetFloat("MovY", 0);
                sprite.flipX = direccion.x < 0;
            }
            else if(direccion.y != 0) 
            {
                anim.SetFloat("MovX", 0);
                anim.SetFloat("MovY", direccion.y);
            }
        }
        if (GameManager.instance.TieneVidasSuficientes(1))
        {
            movimiento = 10f;
        }
        else
        {
            movimiento = 5f;
        }
    }
    private void FixedUpdate()
    {
        if (!puedeMoverse) return;
        rbg.MovePosition(rbg.position + direccion * movimiento * Time.fixedDeltaTime);
    }
}
