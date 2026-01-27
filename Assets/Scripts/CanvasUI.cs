using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    private GameObject pauser;
    //private GameObject pauser1;
    private GameObject pauser2;
    void Start()
    {
        pauser = transform.GetChild(0).gameObject;
        //pauser1 = transform.GetChild(3).gameObject;
        pauser2 = transform.GetChild(4).gameObject;
    }

    public void Regresar()
    {
        pauser.SetActive(false);
        //pauser1.SetActive(false);
        pauser2.SetActive(false);
        Time.timeScale = 1;

    }
}
