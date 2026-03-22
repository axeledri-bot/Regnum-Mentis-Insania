using System.Collections;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    [SerializeField] private float radio = 2f;
    [SerializeField] private LayerMask player;

    [SerializeField] private GameObject pared;


    private bool enAccion = false;

    private void Update()
    {
        if (enAccion) return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, radio, player);

        if (hit != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Accion());
            }
        }
    }

    IEnumerator Accion()
    {
        enAccion = true;

        yield return FadeController.Instance.FadeOut();

 
        AudioManager.instance.Play("");

        CameraShake.instance.Shake(0.4f);
        pared.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        yield return FadeController.Instance.FadeIn();
    }
}

