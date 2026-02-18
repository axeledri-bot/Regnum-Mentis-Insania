using UnityEngine;

public class OrbeDeLuz : MonoBehaviour
{
    [SerializeField] private MagiaDeLuz magiaDeLuz;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            magiaDeLuz.enabled = true;
            Destroy(gameObject);
        }
    }
}
