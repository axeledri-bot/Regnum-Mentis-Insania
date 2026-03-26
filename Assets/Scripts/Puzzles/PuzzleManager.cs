using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Base> bases;
    public List<RompecabezasBase> piezas;
    public int piezasCorrectas;
    public int totalNecesarias;

    public int piezasColocadas = 0;
    public int totalPiezas;

    private List<(RompecabezasBase pieza, Base baseSlot)> colocaciones = new List<(RompecabezasBase, Base)>();

    public GameObject rompecabezas;
    private void Awake()
    {
     GameManager.instance.tieneLlave = false;
    }
    public void PiezaCorrecta()
    {
        piezasCorrectas++;

        if (piezasCorrectas >= totalNecesarias)
        {
            CompletarPuzzle();
        }
    }
    public void RegistrarColocacion(RompecabezasBase pieza, Base baseSlot)
    {
        colocaciones.Add((pieza, baseSlot));
        piezasColocadas++;

        if (piezasColocadas >= totalPiezas)
        {
            EvaluarPuzzle();
        }
    }

    void EvaluarPuzzle()
    {
        bool todoCorrecto = true;

        foreach (var par in colocaciones)
        {
            if (par.pieza.idPieza != par.baseSlot.idCorrecto)
            {
                todoCorrecto = false;
                break;
            }
        }

        if (todoCorrecto)
        {
            CompletarPuzzle();
        }
        else
        {
            FallarPuzzle();
        }
    }
    public void FallarPuzzle()
    {
        Debug.Log("FALLÓ");
        CerrarPuzzle();
        GameManager.instance.PerderVida();
        CameraShake.instance.Shake(0.6f);
        ReiniciarPuzzle();

    }

    void ReiniciarPuzzle()
    {
        foreach (var pieza in piezas)
        {
            pieza.Resetear();
        }
        foreach (var baseSlot in bases)
        {
            baseSlot.ResetearBase();
        }

        colocaciones.Clear();
        piezasColocadas = 0;
    }

    void CompletarPuzzle()
    {
        StartCoroutine(CerrarConDelay());
    }
    IEnumerator CerrarConDelay()
    {
        AudioManager.instance.Play("Exito");
        yield return new WaitForSecondsRealtime(1f);
        bool darLlave = Llave.Instance.RegistrarPuzzleCompletado();

        if (darLlave)
        {
            GameManager.instance.tieneLlave = true;
            Debug.Log("Llave obtenida");
        }

        CerrarPuzzle();
    }

    public void ReiniciarDesdeBoton()
    {
        ReiniciarPuzzle();
    }
    public void CerrarPuzzle()
    {
        rompecabezas.SetActive(false);
        GameManager.instance.ActivarGameplay();
    }
}