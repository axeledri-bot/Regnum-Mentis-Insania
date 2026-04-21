using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject menu;
    private GameObject selector;
    private GameObject controles;
    private GameObject creditos;
    private void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        AudioManager.instance.Play("Menu");
        menu = transform.GetChild(3).gameObject;
        selector = transform.GetChild(4).gameObject;
        controles = transform.GetChild(5).gameObject;
        creditos = transform.GetChild(6).gameObject;
        Cursor.visible = true;

    }
    public void Inicio()
    {
        AudioManager.instance.Play("Boton");
        AudioManager.instance.Stop("Menu");
        GameManager.instance.ResetGame();
        FadeController.Instance.CambiarEscena("Nivel1");
        GameManager.instance.ActivarGameplay();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Seleccion()
    {
        AudioManager.instance.Play("Boton");
        menu.SetActive(false);
        selector.SetActive(true);
    }
    public void Controles()
    {
        AudioManager.instance.Play("Boton");
        menu.SetActive(false);
        controles.SetActive(true);
    }
    public void Creditos()
    {
        AudioManager.instance.Play("Boton");
        menu.SetActive(false);
        creditos.SetActive(true);
    }
    public void Regresar()
    {
        AudioManager.instance.Play("Boton");
        menu.SetActive(true);
        selector.SetActive(false);
        creditos.SetActive(false);
        controles.SetActive(false);
    }
    public void Nivel2()
    {
        AudioManager.instance.Play("Boton");
        AudioManager.instance.Stop("Menu");
        FadeController.Instance.CambiarEscena("Nivel2");
        GameManager.instance.ResetGame();
        GameManager.instance.ActivarGameplay();
    }
    public void Nivel3()
    {
        AudioManager.instance.Play("Boton");
        AudioManager.instance.Stop("Menu");
        FadeController.Instance.CambiarEscena("Nivel3");
        GameManager.instance.ResetGame();
        GameManager.instance.ActivarGameplay();
    }
    public void Salir()
    {
        AudioManager.instance.Play("Boton");
        Application.Quit();
    }
    public void MenuInicio()
    {
        AudioManager.instance.Play("Boton");
        FadeController.Instance.CambiarEscena("Menu");
    }
}
