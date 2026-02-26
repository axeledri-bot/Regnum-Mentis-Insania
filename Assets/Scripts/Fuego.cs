using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fuego : MonoBehaviour
{
    private Light2D m_Light;
    private float tiempo = .5f;
    private bool intensidadAlta;

    private void Awake()
    {
        m_Light = GetComponentInChildren<Light2D>();
    }

    private void FixedUpdate()
    {
        tiempo -= Time.deltaTime;
        if (tiempo < 0)
        {
            Intensidad();
            tiempo = .5f;
            intensidadAlta = !intensidadAlta;
        }
    }

    void Intensidad()
    {
        if (intensidadAlta)
        {
            m_Light.intensity = 3f;
        }
        else
        {

            m_Light.intensity = 5f;
        }
    }
}
