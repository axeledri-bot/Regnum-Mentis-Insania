using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int vidas = 4;
    public Hud hud;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void PerderVida()
    {
        vidas -= 1;
        if (vidas == 0)
        {
            SceneManager.LoadScene("Nivel1");
        }
        hud.DesactivarVida(vidas);
    }
    public bool RecuperarVida()
    {
        if (vidas == 4)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}


