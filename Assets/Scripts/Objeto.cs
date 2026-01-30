using System;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public GameObject objeto;
    public void Interactuar()
    {
        objeto.SetActive(true);
        Destroy(this.gameObject);
        Time.timeScale = 0;
    }
}
