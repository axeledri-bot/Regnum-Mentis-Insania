using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public int vidas = 4;
    public Hud hud;
    [SerializeField] private string escena;
    [SerializeField] private Player mov;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        hud = FindFirstObjectByType<Hud>();
        mov = FindFirstObjectByType<Player>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void PerderVida()
    {
        if (vidas <= 0) return;

        vidas--;

        if (vidas == 1)
        {
            mov.movimiento = 6f;
        }

        if (vidas == 0)
        {
            hud.transform.GetChild(2).gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            mov.movimiento = 3f;
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
        mov.movimiento = 3f;
        return true;
    }
    public void ResetGame()
    {
        vidas = 4;

        if (mov != null)
            mov.movimiento = 3f;

        if (hud != null)
            hud.ResetHUD();
    }
}


