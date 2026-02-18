using System.Collections.Generic;
using UnityEngine;

public class BaseDatosIngredientes : MonoBehaviour
{
    public static BaseDatosIngredientes instance;

    [System.Serializable]
    public class IngredienteData
    {
        public string nombre;
        public Sprite sprite;
    }

    public List<IngredienteData> ingredientes;

    private Dictionary<string, Sprite> diccionario;

    private void Awake()
    {
        instance = this;

        diccionario = new Dictionary<string, Sprite>();

        foreach (var ing in ingredientes)
        {
            diccionario.Add(ing.nombre, ing.sprite);
        }
    }

    public Sprite ObtenerSprite(string nombre)
    {
        if (diccionario.ContainsKey(nombre))
            return diccionario[nombre];

        return null;
    }
}
