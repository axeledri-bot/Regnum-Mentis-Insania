using System;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    [SerializeField] private GameObject[] notas;
    private int index = 0;

    private string sonidoCerrar = "Notas";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Regresar();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            VerSiguienteNota();
        }
    }

    public void Regresar()
    {
        foreach (GameObject nota in notas)
        {
            if (nota != null)
            {
                nota.SetActive(false);
            }
        }

        AudioManager.instance.Play(sonidoCerrar);
        GameManager.instance.ActivarGameplay();
    }
    public void AbrirNotaGuardada(int id)
    {
        foreach (GameObject nota in notas)
        {
            if (nota != null)
            {
                nota.SetActive(false);
            }
        }

        if (id >= 0 && id < notas.Length)
        {
            notas[id].SetActive(true);
        }

        GameManager.instance.ActivarUI();
    }
    public void VerSiguienteNota()
    {
        if (GameManager.instance.notasRecogidas.Count == 0) return;

        index++;

        if (index >= GameManager.instance.notasRecogidas.Count)
            index = 0;

        AbrirNotaGuardada(GameManager.instance.notasRecogidas[index]);
    }
    public void SetSonidos(string abrir, string cerrar)
    {
        sonidoCerrar = cerrar;
    }
}
