using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject menu;
    private GameObject selector;
    private GameObject creditos;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        AudioManager.instance.Play("Menu");
        menu = transform.GetChild(3).gameObject;
        selector = transform.GetChild(4).gameObject;
        creditos = transform.GetChild(5).gameObject;
        Cursor.visible = true;

    }
    public void Inicio()
    {
        AudioManager.instance.Stop("Menu");
        GameManager.instance.ResetGame();
        FadeController.Instance.CambiarEscena("Nivel1");
        GameManager.instance.ActivarGameplay();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Seleccion()
    {
        menu.SetActive(false);
        selector.SetActive(true);
    }
    public void Creditos()
    {
        menu.SetActive(false);
        creditos.SetActive(true);
    }
    public void Regresar()
    {
        menu.SetActive(true);
        selector.SetActive(false);
        creditos.SetActive(false);
    }
    public void Nivel2()
    {
        AudioManager.instance.Stop("Menu");
        FadeController.Instance.CambiarEscena("Nivel2");
        GameManager.instance.ResetGame();
        GameManager.instance.ActivarGameplay();
    }
    public void Nivel3()
    {
        AudioManager.instance.Stop("Menu");
        FadeController.Instance.CambiarEscena("Nivel3");
        GameManager.instance.ResetGame();
        GameManager.instance.ActivarGameplay();
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void MenuInicio()
    {
        FadeController.Instance.CambiarEscena("Menu");
    }
}
