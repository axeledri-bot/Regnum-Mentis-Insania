using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class Transiciones : MonoBehaviour
{
    [SerializeField] private CompositeCollider2D mapa;
    [SerializeField] private Transform puntoSpawn;

    private CinemachineConfiner2D confiner;
    private GameObject player;
    private Movimiento movimiento;
    private bool isOpen;
    private bool enTransicion;

    [SerializeField] private bool requiereCodigo = false;
    [SerializeField] private bool requiereLlave = false;
    //[SerializeField] private string codigoCorrecto = "1234";
    [SerializeField] private GameObject panelCodigo;

    private void Awake()
    {
        confiner = Object.FindFirstObjectByType<CinemachineConfiner2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        movimiento = player.GetComponent<Movimiento>();
    }
    private void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.E) && !enTransicion)
        {
            if (requiereLlave)
            {
                return;
            }
            if (requiereCodigo)
            {
                panelCodigo.SetActive(true);
                player.GetComponent<Movimiento>().puedeMoverse = false;
                return;
            }
            StartCoroutine(Transicion());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            isOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isOpen = false;
        }
    }
    public void AbrirConCodigo()
    {
        StartCoroutine(Transicion());
    }
    IEnumerator Transicion()
    {
        enTransicion = true;

        movimiento.puedeMoverse = false;

        yield return FadeController.Instance.FadeOut();

        confiner.enabled = false;

        Vector3 oldPos = player.transform.position;
        player.transform.position = puntoSpawn.position;

        confiner.BoundingShape2D = mapa;
        isOpen = false;
        confiner.enabled = true;
        confiner.InvalidateBoundingShapeCache();

        var cam = FindFirstObjectByType<CinemachineCamera>();
        cam.OnTargetObjectWarped(player.transform, puntoSpawn.position - oldPos);


        confiner.enabled = false;
        yield return null;
        confiner.enabled = true;

        yield return FadeController.Instance.FadeIn();

        movimiento.puedeMoverse = true;
        enTransicion = false;
    }
}
