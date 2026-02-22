using UnityEngine;

public class PuzzleBiblioteca : MonoBehaviour
{
    [SerializeField] private Librero frente1;
    [SerializeField] private Librero frente2;

    [SerializeField] private Librero atras1;
    [SerializeField] private Librero atras2;



    [HideInInspector]
    public bool puzzleResuelto;
    private void Update()
    {
        if (!puzzleResuelto)
        {
            Verificar();
        }
    }
    void Verificar()
    {
        if ( frente1.libroColocado != null && frente2.libroColocado != null && atras1.libroColocado != null &&  atras2.libroColocado != null )
        {
            string resultadoFrente = CombinarColores(
                frente1.libroColocado.color,
                frente2.libroColocado.color
            );

            string resultadoAtras = CombinarColores(
                atras1.libroColocado.color,
                atras2.libroColocado.color
            );

            bool frenteCorrecto = resultadoFrente == "Verde";
            bool atrasCorrecto = resultadoAtras == "Rosa";

            if (frenteCorrecto && atrasCorrecto)
            {
                puzzleResuelto = true;

                frente1.bloqueado = true;
                frente2.bloqueado = true;
                atras1.bloqueado = true;
                atras2.bloqueado = true;

                Debug.Log("Puzzle completo correctamente");
            }
        }
    }


    string CombinarColores(string c1, string c2)
    {
        if ((c1 == "Rojo" && c2 == "Blanco") || (c1 == "Blanco" && c2 == "Rojo"))
        {
            return "Rosa";
        }



        if ((c1 == "Azul" && c2 == "Amarillo") || (c1 == "Amarillo" && c2 == "Azul"))
        {
            return "Verde";
        }

        return "Nada";
    }
}
