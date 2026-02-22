using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeDialogos : MonoBehaviour
{
    public Palabras[] palabras;

    [Header("Estados")]
    public Palabras[] dialogoIntroduccion;
    public Palabras[] dialogoRecordatorio;
    public Palabras[] dialogoFinal;
    private Palabras[] dialogoForzado;
    private bool usandoDialogoForzado = false;
    private bool yaHabloPrimeraVez = false;

    //Referencia a UI
    [Header("UI")]
    public GameObject sistemaDialogos;
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI texto;
    public Image pers1;
    public Image pers2;
    public Image caja;

    private int linea = 0;

    //Deteccion
    private bool inside;
    [Header("Deteccion")]
    public float radio;
    public LayerMask personaje;

    [SerializeField] private PuzzleBiblioteca puzzle;
    [SerializeField] private Alquimia alquimia;
    [SerializeField] private Player player;
    private void Update()
    {
        inside = Physics2D.OverlapCircle(transform.position, radio, personaje);


        if (!inside && !usandoDialogoForzado) return;

        Palabras[] dialogoActual;


        if (usandoDialogoForzado)
        {
            dialogoActual = dialogoForzado;
        }
        else if ((puzzle != null && puzzle.puzzleResuelto) || (alquimia != null && alquimia.recetaCompletada))
        {
            dialogoActual = dialogoFinal;
        }
        else if (yaHabloPrimeraVez)
        {
            dialogoActual = dialogoRecordatorio;
        }
        else
        {
            dialogoActual = dialogoIntroduccion;
        }


        if (Input.GetKeyDown(KeyCode.E) && linea < dialogoActual.Length)
        {
            sistemaDialogos.SetActive(true);

            nombre.text = dialogoActual[linea].nombre;
            texto.text = dialogoActual[linea].dialogo;
            pers1.sprite = dialogoActual[linea].pers1;
            pers2.sprite = dialogoActual[linea].pers2;
            caja.sprite = dialogoActual[linea].caja;

            linea++;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            sistemaDialogos.SetActive(false);
            if (usandoDialogoForzado)
            {
                usandoDialogoForzado = false;
            }

            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().puedeMoverse = true;
            if (!yaHabloPrimeraVez)
            {
                yaHabloPrimeraVez = true;
            }

            linea = 0;
        }
    }

    public void MostrarDialogoPersonalizado(Palabras[] nuevoDialogo)
    {
        if (nuevoDialogo == null || nuevoDialogo.Length == 0)
        {
            Debug.LogWarning("El dialogo pasado está vacío, no se puede mostrar.");
            return;
        }

        dialogoForzado = nuevoDialogo;
        usandoDialogoForzado = true;
        linea = 0;
        sistemaDialogos.SetActive(true);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().puedeMoverse = true;
    }

}
