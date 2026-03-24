using System.Collections;
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

    [Header("Efecto texto")]
    [SerializeField] private float velocidadTexto = 0.02f;
    private Coroutine escribirCoroutine;
    private bool estaEscribiendo = false;
    private int lineaActualMostrada = 0;

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (estaEscribiendo)
            {
                StopCoroutine(escribirCoroutine);
                texto.text = dialogoActual[lineaActualMostrada].dialogo;
                estaEscribiendo = false;
                return;
            }

            if (linea < dialogoActual.Length)
            {
                sistemaDialogos.SetActive(true);

                nombre.text = dialogoActual[linea].nombre;
                pers1.sprite = dialogoActual[linea].pers1;
                pers2.sprite = dialogoActual[linea].pers2;
                caja.sprite = dialogoActual[linea].caja;

                lineaActualMostrada = linea;

                if (escribirCoroutine != null)
                    StopCoroutine(escribirCoroutine);

                escribirCoroutine = StartCoroutine(
                    EscribirTexto(dialogoActual[linea].dialogo)
                );

                linea++;
            }
            else
            {
                sistemaDialogos.SetActive(false);

                if (usandoDialogoForzado)
                    usandoDialogoForzado = false;

                player.puedeMoverse = true;

                if (!yaHabloPrimeraVez)
                    yaHabloPrimeraVez = true;

                linea = 0;
            }
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

    IEnumerator EscribirTexto(string contenido)
    {
        estaEscribiendo = true;
        texto.text = "";

        int contador = 0;

        foreach (char letra in contenido)
        {
            texto.text += letra;


            if (!char.IsWhiteSpace(letra))
            {
                contador++;
                if (contador % 2 == 0)
                {
                    AudioManager.instance.Play("Dialogo");
                }
            }

            yield return new WaitForSeconds(velocidadTexto);
        }

        AudioManager.instance.Stop("Dialogo");
        estaEscribiendo = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
