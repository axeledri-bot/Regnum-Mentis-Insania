using UnityEngine;

[System.Serializable]
public class Palabras 
{
    public string nombre ="npc";

    [TextArea(3,5)]
    public string dialogo= "Necesitas ir a la cocina primero.";

    public Sprite pers1;
    public Sprite pers2;

    public Sprite caja;
}
