using UnityEngine;

public class PuzzleBiblioteca : MonoBehaviour
{

    public Librero frente1;
    public Librero frente2;

    public Librero atras1;
    public Librero atras2;

    public GameObject luzVerde;

    public bool puzzleResuelto;

    public void Verificar()
    {
        if (puzzleResuelto) return;

        if (frente1.libroActual == null ||
            frente2.libroActual == null ||
            atras1.libroActual == null ||
            atras2.libroActual == null)
            return;

        string frente = Combinar(frente1.libroActual.color, frente2.libroActual.color);
        string atras = Combinar(atras1.libroActual.color, atras2.libroActual.color);

        if (frente == "Verde" && atras == "Rosa")
        {
            puzzleResuelto = true;

            luzVerde.SetActive(true);

            Debug.Log("Puzzle resuelto");
        }
    }

    string Combinar(string a, string b)
    {
        if ((a == "Azul" && b == "Amarillo") || (a == "Amarillo" && b == "Azul"))
            return "Verde";

        if ((a == "Rojo" && b == "Blanco") || (a == "Blanco" && b == "Rojo"))
            return "Rosa";

        return "Nada";
    }
}
