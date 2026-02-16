using System.Collections.Generic;
using UnityEngine;

public class InventarioJugador : MonoBehaviour
{
    public static InventarioJugador instance;

    public List<string> ingredientes = new List<string>();

    private void Awake()
    {
        instance = this;
    }

    public void AgregarIngrediente(string nombre)
    {
        ingredientes.Add(nombre);
        Debug.Log("Inventario: " + nombre);
    }

    public void VaciarInventario()
    {
        ingredientes.Clear();
    }
}
