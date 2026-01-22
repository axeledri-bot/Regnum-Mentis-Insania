using UnityEngine;

public class Alquimia : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Objeto"))
        {
            Destroy(collision.gameObject);
        }
    }
}
