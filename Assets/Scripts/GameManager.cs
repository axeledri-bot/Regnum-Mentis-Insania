using System.Collections;
using System.Collections.Generic;
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

    private Efectos efectos;

    public bool llavePuzzles = false;
    public List<string> llaves = new List<string>();
    [SerializeField] private GameObject uiLlave;
    public bool intentoPuerta;

    public List<int> notasRecogidas = new List<int>();
    public bool EnUI { get; private set; }

    public bool isDead;
    //public GameObject uiAbierta;
 
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
        efectos = FindFirstObjectByType<Efectos>();

        ResetGame();
        SincronizarHUD();

        ActivarGameplay();
    }
    public enum TipoUI
    {
        Ninguna,
        Notas,
        Puzzle,
        GameOver, 
        Pausa
    }

    public TipoUI uiActual { get; private set; } = TipoUI.Ninguna;
    private void Update()
    {
        //if (!EnUI) return;

        //    if (Input.GetKeyDown(KeyCode.Return))
        //    {
        //        CerrarUIActual();
        //    }
    }

    public void ObtenerLlave(string id)
    {
        if (!llaves.Contains(id))
        {
            llaves.Add(id);
        }
    }
    public void MostrarLlaveUI()
    {
        StartCoroutine(MostrarLlave());
    }

    IEnumerator MostrarLlave()
    {
        uiLlave.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);

        uiLlave.SetActive(false);
    }
    //public void CerrarUIActual()
    //{
    //    if (uiAbierta != null)
    //    {
    //        Notas notas = uiAbierta.GetComponent<Notas>();
    //        if (notas != null)
    //        {
    //            notas.Regresar();
    //            uiAbierta = null;
    //            return;
    //        }


    //        Alquimia alquimia = uiAbierta.GetComponent<Alquimia>();
    //        if (alquimia != null)
    //        {
    //            alquimia.CerrarPuzzle();
    //            alquimia.recetaCompletada = true;
    //            uiAbierta = null;
    //            return;
    //        }

    //        uiAbierta.SetActive(false);
    //        ActivarGameplay();
    //        uiAbierta = null;
    //    }
    //}
    private void Awake()
    {
        efectos = FindFirstObjectByType<Efectos>();
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
            AudioManager.instance.Play("Latidos");
            efectos.Activar();
        }

        if (vidas == 0)
        {
            hud.transform.GetChild(2).gameObject.SetActive(true);
            ActivarUI(TipoUI.GameOver);
            mov.movimiento = 3f;
            AudioManager.instance.Stop("Latidos");
            isDead = true;
            efectos.Desactivar();
        }

        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {
        if (vidas == 4)
        {
            return false;
        }
        vidas += 1;
        hud.ActivarVida(vidas - 1);
        mov.movimiento = 3f;
        AudioManager.instance.Stop("Latidos");

        efectos.Desactivar();
        return true;
    }

    void SincronizarHUD()
    {
        if (hud == null) return;


        for (int i = 0; i < hud.vidas.Length; i++)
        {
            hud.vidas[i].SetActive(false);
        }


        for (int i = 0; i < vidas; i++)
        {
            hud.vidas[i].SetActive(true);
        }
    }
    public void ResetGame()
    {
        vidas = 4;
        isDead = false;
        if (mov != null)
            mov.movimiento = 3f;

        if (hud != null)
            hud.ResetHUD();
        if (efectos != null)
            efectos.Desactivar();
        intentoPuerta = false;

        llavePuzzles = false;
        llaves.Clear();

        if (Llave.Instance != null)
        {
            Llave.Instance.Resetear();
        }
    }
    
    public void RegistrarIntentoCocina()
    {
        intentoPuerta = true;
    }
    public void GuardarNota(int id)
    {
        if (!notasRecogidas.Contains(id))
        {
            notasRecogidas.Add(id);
        }
    }
    public void ActivarUI(TipoUI tipo)
    {
        EnUI = true;
        uiActual = tipo;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void ActivarGameplay()
    {
        EnUI = false;
        uiActual = TipoUI.Ninguna;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}


