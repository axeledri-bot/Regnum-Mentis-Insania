[System.Serializable]
public class PlayerData 
{
    public int vida;

    public PlayerData()
    {
        vida = GameManager.instance.vidas;
    }
}
