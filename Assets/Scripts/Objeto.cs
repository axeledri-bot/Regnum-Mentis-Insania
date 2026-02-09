using System;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public GameObject objeto;
    [SerializeField] private bool destruir;
    public void Interactuar()
    {
        objeto.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        if (destruir)
        {
            Destroy(this.gameObject);
        }
        Time.timeScale = 0;
    }
}
