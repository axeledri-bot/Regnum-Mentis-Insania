using System;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public GameObject objeto;
    public void Interactuar()
    {
        objeto.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Destroy(this.gameObject);
        Time.timeScale = 0;
    }
}
