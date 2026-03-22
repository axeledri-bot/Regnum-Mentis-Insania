using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Alquimia : MonoBehaviour, IDropHandler
{
    public List<string> ingredientesActuales = new List<string>();

    public List<string> recetaCorrecta;
    public Transform contenedorUI;
    public GameObject prefabIngredienteUI;
    public RectTransform aleatorio;

    [SerializeField]private GameObject parteCodigo;

    [HideInInspector]
    public bool recetaCompletada;
    public void AbrirPuzzle()
    {
        this.gameObject.SetActive(true);
        GameManager.instance.ActivarUI();
        AudioManager.instance.Play("Alquimia");

        foreach (string ing in InventarioJugador.instance.ingredientes)
        {
            GameObject nuevo = Instantiate(prefabIngredienteUI, contenedorUI);
            nuevo.transform.SetParent(aleatorio, false);
            RectTransform rectTransform = nuevo.GetComponent<RectTransform>();
            float randomX = Random.Range(-aleatorio.rect.width / 2, aleatorio.rect.width/ 2);
            float randomY = Random.Range(-aleatorio.rect.height / 2, aleatorio.rect.height/ 2);
            rectTransform.anchoredPosition = new Vector2(randomX, randomY);
            ObjetosMouse obj = nuevo.GetComponent<ObjetosMouse>();
            obj.Configurar(ing);
        }
       
    }
    public void OnDrop(PointerEventData eventData)
    {
        ObjetosMouse ingrediente = eventData.pointerDrag.GetComponent<ObjetosMouse>();

        if (ingrediente != null)

            if (InventarioJugador.instance.ingredientes.Contains(ingrediente.nombreIngrediente))
            {
                ingredientesActuales.Add(ingrediente.nombreIngrediente);

                ingrediente.gameObject.SetActive(false);

                VerificarReceta();
            }
            else
            {
                Debug.Log("No tienes ese ingrediente");
            }
        }
    private void VerificarReceta()
    {
        Debug.Log("Actual: " + ingredientesActuales.Count);
        Debug.Log("Correcta: " + recetaCorrecta.Count);
        if (ingredientesActuales.Count != recetaCorrecta.Count)
            return;

        for (int i = 0; i < recetaCorrecta.Count; i++)
        {
            if (ingredientesActuales[i] != recetaCorrecta[i])
            {
                Debug.Log("Receta incorrecta");
                Fallo();
                return;
            }
        }
        AudioManager.instance.Stop("Alquimia");
        Debug.Log("¡Poción creada!");
        Recompensa();
    }

    public void Recompensa()
    {
        recetaCompletada = true;

        ingredientesActuales.Clear();
        foreach (Transform hijo in contenedorUI)
        {
            Destroy(hijo.gameObject);
        }

        this.gameObject.SetActive(false);
        GameManager.instance.ActivarUI();
        AudioManager.instance.Play("Exito");

        parteCodigo.SetActive(true);
    }
    public void CerrarPuzzle()
    {
        if (!recetaCompletada && ingredientesActuales.Count > 0)
        {
            Fallo();
            return;
        }

        ResetearPuzzle();

        this.gameObject.SetActive(false);
        GameManager.instance.ActivarGameplay();
        AudioManager.instance.Stop("Alquimia");

    }
    private void Fallo()
    {
        Debug.Log("El caldero explota o se apaga...");

        GameManager.instance.PerderVida();
        CameraShake.instance.Shake(0.6f);

        InventarioJugador.instance.ingredientes.Clear();
        ResetearPuzzle();

        this.gameObject.SetActive(false);
        GameManager.instance.ActivarGameplay();

        GestorIngredientes.instance.LimpiarIngredientes();
        GestorIngredientes.instance.RespawnIngredientes();
    }
    private void ResetearPuzzle()
    {
        ingredientesActuales.Clear();

        foreach (Transform hijo in contenedorUI)
        {
            Destroy(hijo.gameObject);
        }
        AudioManager.instance.Stop("Alquimia");

        recetaCompletada = false;
    }
}


