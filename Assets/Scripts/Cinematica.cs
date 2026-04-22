using TMPro;
using UnityEngine;

public class Cinematica : MonoBehaviour
{

    [SerializeField] private GameObject texto;
    public void CambiarTexto()
    {
        texto.GetComponent<TextMeshProUGUI>().text = "Presiona E para Continuar";
    }
}
