using System;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public GameObject objeto;
    [SerializeField] private bool destruir;
    public Alquimia alquimia;

    [SerializeField] private int idNota;

    [SerializeField] private string sonidoAbrir = "Notas";
    [SerializeField] private string sonidoCerrar = "Notas";
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

            Notas notas = objeto.GetComponent<Notas>();
            if (notas != null)
            {
                notas.SetSonidos(sonidoAbrir, sonidoCerrar); 
            }
            GameManager.instance.GuardarNota(idNota);
        }

        AudioManager.instance.Play(sonidoAbrir);
        GameManager.instance.ActivarUI();

        if (destruir)
        {
            Destroy(this.gameObject);
        }
       
    }
}
