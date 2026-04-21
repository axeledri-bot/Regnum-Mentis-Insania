using System.Collections;
using UnityEngine;

public class XpLogo : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Logo());
    }

    IEnumerator Logo()
    {
        yield return FadeController.Instance.FadeIn();

        yield return new WaitForSeconds(1f);

        FadeController.Instance.CambiarEscena("Menu");
    }
}
