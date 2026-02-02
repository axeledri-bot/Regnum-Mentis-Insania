using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject menu;
    private GameObject selector;
    private GameObject creditos;
    private void Start()
    {
        menu = transform.GetChild(1).gameObject;
        selector = transform.GetChild(2).gameObject;
        creditos = transform.GetChild(3).gameObject;
    }
    public void Inicio()
    {
        SceneManager.LoadScene("Nivel1");
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
        SceneManager.LoadScene("");
    }
    public void Nivel3()
    {
        SceneManager.LoadScene("");
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
