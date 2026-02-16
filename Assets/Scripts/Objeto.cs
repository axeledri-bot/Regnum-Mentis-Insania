using System;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public GameObject objeto;
    [SerializeField] private bool destruir;
    public Alquimia alquimia;
    public void Interactuar()
    {
        if (alquimia != null)
        {
            alquimia.AbrirPuzzle();
            return;
        }

        if (objeto != null)
        {
            objeto.SetActive(true);
        }

       GameManager.instance.ActivarUI();

        if (destruir)
        {
            Destroy(this.gameObject);
        }
       
    }
}
