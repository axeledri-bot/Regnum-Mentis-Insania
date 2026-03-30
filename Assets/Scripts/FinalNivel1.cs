using UnityEngine;

public class FinalNivel1 : MonoBehaviour
{
    private bool Cambio;

    private void Update()
    {
        if (Cambio && Input.GetKeyUp(KeyCode.E))
        {
            AudioManager.instance.Stop("Nivel 1");
            AudioManager.instance.Stop("Ambiente Nivel 1");
            FadeController.Instance.CambiarEscena("Nivel2");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cambio = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Cambio = false;
        }
    }
}

