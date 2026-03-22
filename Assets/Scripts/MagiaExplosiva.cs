using UnityEngine;

public class MagiaExplosiva : MonoBehaviour
{
    [SerializeField] private TimeStop timeStop;
    [SerializeField] private GameObject tMHud;
    [SerializeField] private GameObject mHud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeStop.enabled = false;
            tMHud.SetActive(false);
            mHud.SetActive(true);
            Destroy(gameObject);
        }
    }
}
