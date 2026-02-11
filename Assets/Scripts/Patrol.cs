using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]private Transform[] puntos;
    private Enemy enemy;
    [SerializeField]private float tiempo;

    private bool esperando;
    private int puntoActual;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        if (transform.position != puntos[puntoActual].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntos[puntoActual].position, enemy.velocidad * Time.deltaTime);
        }
        else if(!esperando)
        {
            StartCoroutine(Esperar());
        }
    }
    IEnumerator Esperar()
    {
        esperando = true;
        yield return new WaitForSeconds(tiempo);
        puntoActual++;
        if (puntoActual == puntos.Length)
        {
            puntoActual = 0;    
        }
        esperando = false;
        Flip();
    }
    private void Flip()
    {
        if (transform.position.x > puntos[puntoActual].position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
