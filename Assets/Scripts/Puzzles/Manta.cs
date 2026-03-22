using UnityEngine;

public class Manta : MonoBehaviour
{

    [SerializeField] private GameObject cama;
    private bool recogida;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !recogida)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                RecojerManta.tieneManta = true;

                cama.SetActive(true);
                AudioManager.instance.Play("Manta 2");
                recogida = true;
            }
        }
    }
}
