using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    private GameObject pauser;
    void Start()
    {
        pauser = transform.GetChild(0).gameObject;
    }

    public void Regresar()
    {
        pauser.SetActive(false);
        Time.timeScale = 1;

    }
}
