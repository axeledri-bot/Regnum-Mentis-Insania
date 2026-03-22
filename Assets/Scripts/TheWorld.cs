using UnityEngine;

public class TheWorld : MonoBehaviour
{
    [SerializeField] private TimeStop timeStop;
    [SerializeField] private GameObject tMHud;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeStop.enabled = true;
            tMHud.SetActive(true);
            Destroy(gameObject);
        }
    }
}
