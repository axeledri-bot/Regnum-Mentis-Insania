using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Codigo : MonoBehaviour
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
        }
    }
}

