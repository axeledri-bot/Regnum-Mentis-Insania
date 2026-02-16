using UnityEngine;

public class PartesCodigo : MonoBehaviour
{
  [SerializeField] private GameObject parteCodigo;

    public void Cerrar()
    {
        parteCodigo.SetActive(false);
        GameManager.instance.ActivarGameplay();
    }
}
