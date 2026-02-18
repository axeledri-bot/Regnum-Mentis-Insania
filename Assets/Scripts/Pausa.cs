using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    //private GameObject pauser;
    [SerializeField]private Animator animator;

    private bool paused;
    public string escena;


    private void Start()
    {
        //pauser = transform.GetChild(1).gameObject;

    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*&& !paused*/)
        {
            if (GameManager.instance.EnUI) return;
            //pauser.SetActive(true);
            paused = !paused;
            animator.SetBool("MostrarMenu", paused);
            //paused = true;
          if( paused )
            {
                GameManager.instance.ActivarUI();
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
        paused = false;
        animator.SetBool("MostrarMenu", false);
        GameManager.instance.ActivarGameplay();
    }
    public void Reiniciar()
    { 
        GameManager.instance.ResetGame();
        SceneManager.LoadScene(escena);
        GameManager.instance.ActivarGameplay();

    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
