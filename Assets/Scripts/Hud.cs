using UnityEngine;
using UnityEngine.Video;

public class Hud : MonoBehaviour
{
    public GameObject[] vidas;

    public void DesactivarVida(int damage )
    {
        vidas[damage].SetActive(false);
    }    
    public void ActivarVida( int damage )
    {
        vidas[damage].SetActive(true);
    }    
}
