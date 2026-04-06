using UnityEngine;

public class LlaveNivel2 : MonoBehaviour
{
    [SerializeField] private string idLlave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.ObtenerLlave(idLlave);
            Destroy(gameObject);
        }

    }

}
