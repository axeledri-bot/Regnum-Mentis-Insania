using System.Collections;
using TMPro;
using UnityEngine;

public class Pensamientos : MonoBehaviour
{
    public static Pensamientos instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text texto;

    [SerializeField] private float letra = 0.03f;
    [SerializeField] private float duracion = 3f;

    private Coroutine actual;

    private void Awake()
    {
        instance = this;
        panel.SetActive(false);
    }

    public void Mostrar(string pensamiento)
    {
        if (actual != null)
            StopCoroutine(actual);

        actual = StartCoroutine(MostrarDialogo(pensamiento));
    }

    private IEnumerator MostrarDialogo(string pensamiento)
    {
        panel.SetActive(true);
        texto.text = "";

        foreach (char letter in pensamiento)
        {
            texto.text += letter;
            yield return new WaitForSeconds(letra);
        }
        yield return new WaitForSeconds(duracion);

        panel.SetActive(false);
    }
}
