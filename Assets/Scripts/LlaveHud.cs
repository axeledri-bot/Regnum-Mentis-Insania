using UnityEngine;

public class LlaveHud : MonoBehaviour
{
    [SerializeField] private GameObject parteCodigo;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Cerrar();
        }
    }
    public void Cerrar()
    {
        parteCodigo.SetActive(false);
        GameManager.instance.ActivarGameplay();
    }
}
