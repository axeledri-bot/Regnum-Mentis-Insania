using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    private GameObject pauser;

    private bool paused;
    

    public string escena;


    private void Start()
    {
        pauser = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !paused)
        {
            pauser.SetActive(true);
            paused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && paused)
        {
            pauser.SetActive(false);
            paused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Regresar()
    {
        pauser.SetActive(false);
        paused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(escena);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
