using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int vidas = 4;
    public Hud hud;
    [SerializeField] private string escena;
    [SerializeField]private Movimiento mov;

   
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
        if (vidas <= 0) return;

        vidas--;

        if (vidas == 1)
        {
            mov.movimiento = 10f;
        }

        if (vidas == 0)
        {
            hud.transform.GetChild(2).gameObject.SetActive(true);
            Time.timeScale = 0;
            mov.movimiento = 5f;
        }

        hud.DesactivarVida(vidas);
    }
    public bool TieneVidasSuficientes(int cantidad)
    {
        return vidas <= cantidad;
    }
    public bool RecuperarVida()
    {
        if (vidas == 4)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
        mov.movimiento = 5f;
        return true;
    }
}


