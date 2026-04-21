using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    //private GameObject pauser;
    [SerializeField]private Animator animator;

    private bool paused;
    public string escena;

    [SerializeField] private string music;
    [SerializeField] private string efecto;

    private void Start()
    {
        //pauser = transform.GetChild(1).gameObject;

    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*&& !paused*/)
        {
            if (GameManager.instance.EnUI && !paused) return;
            //pauser.SetActive(true);
            paused = !paused;
            animator.SetBool("MostrarMenu", paused);
            //paused = true;
          if( paused )
            {
                GameManager.instance.ActivarUI(GameManager.TipoUI.Pausa);
            }
          else
            {
                GameManager.instance.ActivarGameplay();
            }
        }
        //else if (Input.GetKeyDown(KeyCode.Return) /*&& paused*/)
        //{
        //    //pauser.SetActive(false);
        //    paused = false;
        //    Time.timeScale = 1;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }

    public void Regresar()
    {
        //pauser.SetActive(false);
        AudioManager.instance.Play("Boton");
        paused = false;
        animator.SetBool("MostrarMenu", false);
        GameManager.instance.ActivarGameplay();
    }
    public void Reiniciar()
    {
        AudioManager.instance.Play("Boton");

        FadeController.Instance.CambiarEscena(escena);
        GameManager.instance.ActivarGameplay();

    }

    public void Menu()
    {
        AudioManager.instance.Play("Boton");
        AudioManager.instance.Stop(music);
        AudioManager.instance.Stop(efecto);
        Time.timeScale = 1;
        FadeController.Instance.CambiarEscena("Menu");

    }
}
