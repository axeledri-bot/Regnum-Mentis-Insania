
using System.Collections;
using UnityEngine;

public class Ojo : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private float distanciaMaxima = 10f;
    [SerializeField] private LayerMask silla;
    [SerializeField] private Transiciones puerta;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite ojoTapado;
    private bool enAccion;

    [SerializeField]private float cerca = 2f;
    [SerializeField] private LayerMask player;



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 origen = transform.position;
 

        //RaycastHit2D hit = Physics2D.OverlapCircle(origen, cerca, player);
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    StartCoroutine(Accion());
        //}

    }
    private void LateUpdate()
    {
        if (jugador != null)
        {
            if (enAccion) return;

            Vector3 dir = jugador.position - transform.position;

            float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        }
    }

    IEnumerator Accion()
    {
        enAccion = true;

        yield return FadeController.Instance.FadeOut();

        spriteRenderer.sprite = ojoTapado;

        yield return FadeController.Instance.FadeIn();



    }
    public bool EstaViendoJugador()
    {
        if (enAccion) return false;

        Vector2 direccion = jugador.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion.normalized, distanciaMaxima, silla);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            return true;

        }
        return false;
    }

}

