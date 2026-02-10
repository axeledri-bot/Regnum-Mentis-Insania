using System.Collections;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    [SerializeField] private float duracion;
    private bool activo;

    private Player jugador;
    private void Start()
    {
        jugador = GetComponent<Player>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !activo)
        {
        
            StartCoroutine(DetenerTiempo());
        }
    }
    IEnumerator DetenerTiempo()
    {
        activo = true;

        jugador.theWorld = true;
        Time.timeScale = 0f;
        efecto.SetActive(true);

        float limite = 0f;
        while (limite < duracion)
        {
            limite += Time.unscaledDeltaTime;
            yield return null;
        }
        efecto.SetActive(false);
        Time.timeScale = 1f;
        jugador.theWorld = false;

        activo = false;
    }
}
