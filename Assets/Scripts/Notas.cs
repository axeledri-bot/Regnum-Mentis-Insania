using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Notas : MonoBehaviour
{
    private GameObject Nota;
    private GameObject Nota1;
    private GameObject Nota2;
    private GameObject Nota3;
    private GameObject Nota4;
    private GameObject Nota5;
    void Start()
    {
        Nota = transform.GetChild(0).gameObject;
        Nota1 = transform.GetChild(1).gameObject;
        Nota2 = transform.GetChild(2).gameObject;
        Nota3 = transform.GetChild(3).gameObject;
        Nota4 = transform.GetChild(4).gameObject;
        Nota5 = transform.GetChild(5).gameObject;
    }
    public void Regresar()
    {
        Nota.SetActive(false);
        Nota1.SetActive(false);
        Nota2.SetActive(false);
        Nota3.SetActive(false);
        Nota4.SetActive(false);
        Nota5.SetActive(false);
        GameManager.instance.ActivarGameplay();
    }
}
