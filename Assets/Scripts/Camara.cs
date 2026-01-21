using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    public float velocidad = 0.025f;
    public Vector3 desplazamiento;

    private void Update()
    {
        Vector3 posicion = player.position + desplazamiento;

        Vector3 objetivo = Vector3.Lerp(transform.position, posicion, velocidad);

        transform.position = objetivo;
    }
}
