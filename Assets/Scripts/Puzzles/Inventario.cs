using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] private Transform agarre;
    private GameObject objeto;
    [SerializeField]private float distancia = 1f;
    [SerializeField]private LayerMask objetos;
    private bool sosteniendo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (sosteniendo)
            {
                SoltarObjeto();
            }
            else
            {
                AgarrarObjeto();
            }
        }
        if(sosteniendo && objeto != null) 
        { 
            objeto.transform.position = agarre.position;    
        }
    }
    private void AgarrarObjeto()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, distancia, Vector2.zero, 0f, objetos);
        if(hit.collider != null)
        {
            objeto = hit.collider.gameObject;

            objeto.transform.SetParent(agarre);

            sosteniendo = true;

            if(objeto.GetComponent<Rigidbody2D>()) 
            { 
            objeto.GetComponent<Rigidbody2D>().simulated = false;
            }
        }

    }

    private void SoltarObjeto()
    {
        objeto.transform.SetParent(null);
        if (objeto.GetComponent<Rigidbody2D>())
        {
            objeto.GetComponent<Rigidbody2D>().simulated = true;
        }

        objeto = null;
        sosteniendo = false;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distancia);
    }
}
