using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float movimiento = 5f;
    private Vector2 direccion;
    private Rigidbody2D rbg;
    private float direccionX;
    private float direccionY;

    private void Start()
    {
        rbg = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

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
        rbg.MovePosition(rbg.position + direccion * movimiento * Time.fixedDeltaTime);
    }
}
