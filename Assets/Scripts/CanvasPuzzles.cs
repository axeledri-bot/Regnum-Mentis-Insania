using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CanvasPuzzles : MonoBehaviour
{
    private GameObject puzzle;
    void Start()
    {
     puzzle = transform.GetChild(0).gameObject;

    }
    public void Regresar()
    {
        puzzle.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
