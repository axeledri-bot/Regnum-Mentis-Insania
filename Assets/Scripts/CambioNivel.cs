using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    [SerializeField] private string escena;
    [SerializeField] private string musicStop;
    [SerializeField] private string effectStop;

    //public int colNecesarios = 3;
    //public GameObject mensaje;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") /*&& Input.GetKeyDown(KeyCode.E)*/)
        {
            //if (GameManager.instance.moneda >= colNecesarios)
            //{
            AudioManager.instance.Stop(musicStop);
            AudioManager.instance.Stop("Fuego");
            AudioManager.instance.Stop(effectStop);
            FadeController.Instance.CambiarEscena(escena);


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
