using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeStop : MonoBehaviour
{
    [SerializeField] private Volume timeStopEffect;
    [SerializeField] private float duracion;
    [SerializeField] private float coolDown = 2f;
    private bool activo;

    private bool puedeUsar = true;
    private Player jugador;
    private void Start()
    {
        jugador = GetComponent<Player>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !activo && puedeUsar)
        {

            StartCoroutine(DetenerTiempo());
        }
    }
    IEnumerator DetenerTiempo()
    {
        puedeUsar = false;
        activo = true;

        jugador.theWorld = true;
        jugador.ActivarModoTiempoDetenido();
        float t = 0f;
        while (t < 0.15f)
        {
            t += Time.unscaledDeltaTime;
            timeStopEffect.weight = Mathf.Lerp(0f, 1f, t / 0.15f);
            yield return null;
        }
        Time.timeScale = 0f;
      

        AudioManager.instance.Play("Reloj");

        float limite = 0f;
        while (limite < duracion)
        {
            limite += Time.unscaledDeltaTime;
            yield return null;
        }


        Time.timeScale = 1f;
        jugador.theWorld = false;
        jugador.DesactivarModoTiempoDetenido();
        AudioManager.instance.Stop("Reloj");

        t = 0f;
        while (t < 0.2f)
        {
            t += Time.unscaledDeltaTime;
            timeStopEffect.weight = Mathf.Lerp(1f, 0f, t / 0.2f);
            yield return null;
        }

        activo = false;
       
        yield return new WaitForSecondsRealtime(coolDown);

        puedeUsar = true;
    }
}
