using System.Collections;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    [SerializeField] private float duracion;
    private bool activo;

    private Movimiento jugador;
    private void Start()
    {
        jugador = GetComponent<Movimiento>();
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

        float limite = 0f;
        while (limite < duracion)
        {
            limite += Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1f;
        jugador.theWorld = false;

        activo = false;
    }
}
