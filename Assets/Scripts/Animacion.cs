using UnityEngine;

public class Animacion : MonoBehaviour
{
    [SerializeField] private MagiaDeLuz MagiaDeLuz;
    [SerializeField] private GameObject LuzHud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MagiaDeLuz.SecuenciaLuzCinematica());
            LuzHud.SetActive(false);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
