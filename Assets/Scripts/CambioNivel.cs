using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    public string escena;
    //public int colNecesarios = 3;
    //public GameObject mensaje;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (GameManager.instance.moneda >= colNecesarios)
            //{
                SceneManager.LoadScene(escena);
            //}
            //else 
            //{
            //    mensaje.SetActive(true);
            //}
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        mensaje.SetActive(false);
    //    }
    //}
}
