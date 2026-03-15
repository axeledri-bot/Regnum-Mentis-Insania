using UnityEngine;

public class DañosLuz : MonoBehaviour
{
    [SerializeField] private MagiaDeLuz magiaDeLuz;
    [SerializeField] private GameObject magiaHud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            magiaDeLuz.enabled = true;
            magiaHud.SetActive(true);
            Destroy(gameObject);
        }
    }
}
