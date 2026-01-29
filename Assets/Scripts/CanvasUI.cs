using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
   
    private GameObject[] pauser;

    void Start()
    {
     

    }
    public void Puzzles(int cantidad)
    {
        pauser[cantidad].SetActive(true);
        
    }
    public void Regresar(int cantidad)
    {
        pauser[cantidad].SetActive(false);
        Time.timeScale = 1;
    }
}
