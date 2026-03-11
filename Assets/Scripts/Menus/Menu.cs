using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject menu;
    private GameObject selector;
    private GameObject creditos;
    private void Start()
    {
        AudioManager.instance.Play("Menu");
        menu = transform.GetChild(3).gameObject;
        selector = transform.GetChild(4).gameObject;
        creditos = transform.GetChild(5).gameObject;
    }
    public void Inicio()
    {
        AudioManager.instance.Stop("Menu");
 
        SceneManager.LoadScene("Nivel1");
        AudioManager.instance.Play("Nivel 1");
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
        SceneManager.LoadScene("Nivel2");
        AudioManager.instance.Play("Nivel 2");
    }
    public void Nivel3()
    {
        AudioManager.instance.Stop("Menu");
        SceneManager.LoadScene("Nivel3");
        AudioManager.instance.Play("Nivel 3");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void MenuInicio()
    {
        SceneManager.LoadScene("Menu");
    }
}
