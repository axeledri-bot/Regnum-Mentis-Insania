using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class Transiciones : MonoBehaviour
{
    [SerializeField] private CompositeCollider2D mapa;
    [SerializeField] private Transform puntoSpawn;

    private CinemachineConfiner2D confiner;
    private GameObject player;
    private Player movimiento;
    private bool isOpen;
    private bool enTransicion;

    [SerializeField] private bool requiereLlave;
    [SerializeField] private bool requiereCodigo;
    [SerializeField] private bool desbloqueada;
    [SerializeField] private string codigoCorrecto = "1234";
    [SerializeField] private GameObject panelCodigo;
    private bool panelAbierto;
    public string CodigoCorrecto => codigoCorrecto;


    [SerializeField] private bool requiereCamaraTapada;
    [SerializeField] private Ojo camara;

    [SerializeField] private bool esPuertaCocina;

    [SerializeField] private bool requiereIrCocina;
    private void Awake()
    {
        confiner = Object.FindFirstObjectByType<CinemachineConfiner2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        movimiento = player.GetComponent<Player>();
    }
    private void LateUpdate()
    {

        if (isOpen && Input.GetKeyDown(KeyCode.E) && !enTransicion)
        {
            if (requiereIrCocina && !GameManager.instance.intentoPuerta)
            {
                Debug.Log("No puedes abrir esta puerta todavía.");
                return;
            }
            if (esPuertaCocina && !GameManager.instance.intentoPuerta)
            {
                GameManager.instance.RegistrarIntentoCocina();
            }

            if (requiereLlave)
            {
                if (!GameManager.instance.tieneLlave)
                {
                  

                    Debug.Log("Necesitas una llave");
                    return;
                }
            }
            if (requiereCodigo && !desbloqueada)
            {
                if (panelAbierto)
                {
                    return;
                }
                
                panelAbierto = true;
                panelCodigo.SetActive(true);
                GameManager.instance.ActivarUI();
                player.GetComponent<Player>().puedeMoverse = false;
                return;
            }
            if (requiereCamaraTapada)
            {
                if (camara.EstaViendoJugador())
                {
                    Debug.Log("La cámara te está viendo...");
                    return;
                }
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
    public void AbrirConCodigo()
    {
        desbloqueada = true;
        panelAbierto = false;
        GameManager.instance.ActivarGameplay();
        StartCoroutine(Transicion());
    }
    public void CancelarCodigo()
    {
        panelAbierto = false;
        player.GetComponent<Player>().puedeMoverse = true;
        GameManager.instance.ActivarGameplay();
        enTransicion = false;
    }
}
