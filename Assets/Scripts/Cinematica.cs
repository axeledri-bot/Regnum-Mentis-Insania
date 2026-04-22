using TMPro;
using UnityEngine;

public class Cinematica : MonoBehaviour
{

    [SerializeField] private GameObject texto;
    public void CambiarTexto()
    {
        texto.GetComponent<TextMeshProUGUI>().text = "Presiona E para Continuar";
    }
    public void Sonido1()
    {
        AudioManager.instance.Play("Sonido1");
    }    
    public void Sonido2()
    {
        AudioManager.instance.Play("Sonido2");
    } 
    public void Sonido3()
    {
        AudioManager.instance.Play("Sonido3");
    }
}
