using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    [SerializeField] private string escena;
    [SerializeField] private string musicStop;
    [SerializeField] private string effectStop;
    [SerializeField] private string musicPlay;
    [SerializeField] private string effectPlay;
    //public int colNecesarios = 3;
    //public GameObject mensaje;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") /*&& Input.GetKeyDown(KeyCode.E)*/)
        {
            //if (GameManager.instance.moneda >= colNecesarios)
            //{
            AudioManager.instance.Stop(musicStop);
            AudioManager.instance.Stop(effectStop);
            AudioManager.instance.Stop("Fuego");
            FadeController.Instance.CambiarEscena(escena);
            AudioManager.instance.Play(musicPlay);
            AudioManager.instance.Play(effectPlay);


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
