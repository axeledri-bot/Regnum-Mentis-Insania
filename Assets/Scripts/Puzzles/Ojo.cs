using UnityEngine;

public class Ojo : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private float distanciaMaxima = 10f;
    [SerializeField] private LayerMask silla;
    [SerializeField] private Transiciones puerta;

    public bool EstaViendoJugador()
    {
        Debug.Log("Chequeando vision...");
        Vector2 direccion = jugador.position - transform.position;
        Debug.DrawRay(transform.position, direccion, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(  transform.position,  direccion.normalized, distanciaMaxima, silla);
    
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            return true;

        }
        return false;
    }
   
}

