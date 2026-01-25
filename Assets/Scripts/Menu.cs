using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject selector;
    private GameObject creditos;
    private void Start()
    {
        selector = transform.GetChild(7).gameObject;
        creditos = transform.GetChild(8).gameObject;
    }
    public void Inicio()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Seleccion()
    {
        selector.SetActive(true);
    }
    public void Creditos()
    {
        creditos.SetActive(true);
    }
    public void Regresar()
    {
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
