
using UnityEngine;

public class Ojo : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private float distanciaMaxima = 10f;
    [SerializeField] private LayerMask silla;
    [SerializeField] private Transiciones puerta;

    private void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 dir = jugador.position - transform.position;

            float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        }
    }
    public bool EstaViendoJugador()
    {
        Vector2 direccion = jugador.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion.normalized, distanciaMaxima, silla);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            return true;

        }
        return false;
    }

}

