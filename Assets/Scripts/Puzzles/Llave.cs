using UnityEngine;

public class Llave : MonoBehaviour
{
    public static Llave Instance;

    private int puzzlesCompletados = 0;

    private void Awake()
    {
        Instance = this;

    }

    public bool RegistrarPuzzleCompletado()
    {
        puzzlesCompletados++;

        if (puzzlesCompletados >= 3)
        {
            GameManager.instance.llavePuzzles = true;
            GameManager.instance.MostrarLlaveUI();
            return true;
        }

        return false;
    }
    public void Resetear()
    {
        puzzlesCompletados = 0;
    }
}
