using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    [SerializeField] private GameObject[] notas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Regresar();
        }
    }

    public void Regresar()
    {
        foreach (GameObject nota in notas)
        {
            if (nota != null)
                nota.SetActive(false);
        }

        GameManager.instance.ActivarGameplay();
    }
}
