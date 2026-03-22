using UnityEngine;

public class CtrlLluvia : MonoBehaviour
{
    [SerializeField] private GameObject lluvia;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lluvia.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lluvia.SetActive(true);
        }
    }

}
