using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    private GameObject pauser;
    [SerializeField]private Animator animator;

    private bool paused;
    public string escena;


    private void Start()
    {
        //pauser = transform.GetChild(1).gameObject;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*&& !paused*/)
        {
            //pauser.SetActive(true);
            paused = !paused;
            animator.SetBool("MostrarMenu", paused);
            //paused = true;
            Time.timeScale = paused ? 0 : 1;

            Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;

            Cursor.visible = paused;
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
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Reiniciar()
    { 
        Time.timeScale = 1;
        GameManager.instance.ResetGame();
        SceneManager.LoadScene(escena);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = paused;

    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
