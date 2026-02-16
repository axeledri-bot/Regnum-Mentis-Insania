using System.Collections.Generic;
using UnityEngine;

public class GestorIngredientes : MonoBehaviour
{
    public static GestorIngredientes instance;

    public List<GameObject> prefabsIngredientes;
    public List<Transform> puntosSpawn;

    public string tagIngrediente = "Ingrediente";
    private void Awake()
    {
        instance = this;
    }

    public void RespawnIngredientes()
    {
        for (int i = 0; i < prefabsIngredientes.Count; i++)
        {
            Instantiate(prefabsIngredientes[i], puntosSpawn[i].position, Quaternion.identity);
        }
    }
    public void LimpiarIngredientes()
    {
        GameObject[] existentes = GameObject.FindGameObjectsWithTag(tagIngrediente);

        foreach (GameObject obj in existentes)
        {
            Destroy(obj);
        }
    }
}
