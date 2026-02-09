using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Alquimia : MonoBehaviour, IDropHandler
{
    public List<string> ingredientesActuales = new List<string>();

    public List<string> recetaCorrecta;

    public void OnDrop(PointerEventData eventData)
    {
 
        ObjetosMouse ingrediente = eventData.pointerDrag.GetComponent<ObjetosMouse>();

        if (ingrediente != null)
        {
            ingredientesActuales.Add(ingrediente.nombreIngrediente);
            Debug.Log("Agregado: " + ingrediente.nombreIngrediente);

            Destroy(ingrediente.gameObject);
            VerificarReceta();
        }
    }
    private void VerificarReceta()
    {
        if (ingredientesActuales.Count != recetaCorrecta.Count)
        {
            return;
        }

        foreach (string ingrediente in recetaCorrecta)
        {
            if (!ingredientesActuales.Contains(ingrediente))
            {
                return;
            }
        }

        Debug.Log("¡Poción creada!");
        CerrarPuzzle();
    }
    public void CerrarPuzzle()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

