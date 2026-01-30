using UnityEngine;

public class Vidas : MonoBehaviour
{
    private bool vidaRecuperada;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vidaRecuperada = GameManager.instance.RecuperarVida();
            if (vidaRecuperada)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
      
