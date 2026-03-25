using UnityEngine;

public class Llave : MonoBehaviour
{
    public static Llave Instance;

    private int puzzlesCompletados = 0;

    private void Awake()
    {
        Instance = this;
        puzzlesCompletados = 0;
    }

    public bool RegistrarPuzzleCompletado()
    {
        puzzlesCompletados++;

        if (puzzlesCompletados >= 3)
        {
            return true;
        }

        return false;
    }
}
