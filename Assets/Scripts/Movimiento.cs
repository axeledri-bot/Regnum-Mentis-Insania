using System.Collections;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float movimiento = 5f;
    private Vector2 direccion;
    private Rigidbody2D rbg;
    private float direccionX;
    private float direccionY;

    public float tiempoInvencible = 0.5f;
    public float fuerzaRebote = 6f;
    //private bool damage;
    public bool puedeMoverse = true;
    private void Start()
    {
        rbg = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!puedeMoverse)
        {
            direccion = Vector2.zero;
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
    }
    private void FixedUpdate()
    {
        if (!puedeMoverse) return;
        rbg.MovePosition(rbg.position + direccion * movimiento * Time.fixedDeltaTime);
    }
}
//    public void Vida(Vector2 direccion, int cantidad)
//    {
//        if (!damage)
//        {
//            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized;

//            rbg.linearVelocity = Vector2.zero;
//            rbg.AddForce(rebote * fuerzaRebote, ForceMode2D.Impulse);
//            StartCoroutine(Invencibilidad());
//        }
//    }
//    IEnumerator Invencibilidad()
//    {
//        yield return new WaitForSeconds(tiempoInvencible);
//        damage = false;
//    }

//}
