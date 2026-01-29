using Unity.Cinemachine;
using UnityEngine;

public class Transiciones : MonoBehaviour
{
    [SerializeField] private CompositeCollider2D mapa;
    [SerializeField] private Transform puntoSpawn;

    private CinemachineConfiner2D confiner;
    private  GameObject player;

    private void Awake()
    {
        confiner = Object.FindFirstObjectByType<CinemachineConfiner2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") /*&& Input.GetKeyDown(KeyCode.E)*/)
        {
            confiner.enabled = false;
            confiner.BoundingShape2D = mapa;
            player.transform.position = puntoSpawn.position;
            confiner.enabled = true;
            confiner.InvalidateBoundingShapeCache();
        }
    }
}
