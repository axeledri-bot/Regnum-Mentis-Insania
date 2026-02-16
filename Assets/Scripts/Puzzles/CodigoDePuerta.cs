using TMPro;
using UnityEngine;

public class CodigoDePuerta : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textoCodigo;
    [SerializeField] private Transiciones puerta;

    private string codigoIngresado = "";

    private bool activo;
    private void OnEnable()
    {
        activo = true;
    }

    private void OnDisable()
    {
        activo = false;
    }

    private void Update()
    {
        if (activo && Input.GetKeyDown(KeyCode.Return))
        {
            CerrarPanel();
        }
    }

    public void AgregarNumero(string numero)
    {
        if (codigoIngresado.Length >= 4)
        {
            return;
        }
        codigoIngresado += numero;
        textoCodigo.text = codigoIngresado;
    }

    public void Borrar()
    {
        codigoIngresado = "";
        textoCodigo.text = "* * * *";
    }

    public void Confirmar()
    {
        if (codigoIngresado == puerta.CodigoCorrecto)
        {
            transform.parent.gameObject.SetActive(false);
            puerta.AbrirConCodigo();
        }
        else
        {
            Borrar();
        }
    }
    private void CerrarPanel()
    {
        codigoIngresado = "";
        textoCodigo.text = "* * * *";

        transform.parent.gameObject.SetActive(false);
        puerta.CancelarCodigo();
        GameManager.instance.ActivarGameplay();
    }
}


