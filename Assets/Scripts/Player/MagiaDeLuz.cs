using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MagiaDeLuz : MonoBehaviour
{
    [SerializeField] private GameObject luz;
    [SerializeField] private float duracion = 1f;
    [SerializeField] private float coolDown = 2f;

    private bool puedeUsar = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && puedeUsar)
        {
           StartCoroutine(ActivarLuz());
        }
    }

    IEnumerator ActivarLuz()
    {
        puedeUsar = false;

        luz.SetActive(true);

        yield return new WaitForSeconds(duracion);

        luz.SetActive(false);

        yield return new WaitForSeconds(coolDown);

        puedeUsar = true;
    }
}


