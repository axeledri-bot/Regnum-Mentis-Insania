using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MagiaDeLuz : MonoBehaviour
{
    [SerializeField] private Light2D luz;
    [SerializeField] private float duracion = 1f;
    [SerializeField] private float coolDown = 2f;
    [SerializeField] private float intensity = 2f;
    [SerializeField]private Volume volume;
    private Bloom bloom;

    [SerializeField] private GameObject ondaPrefab;
    private bool puedeUsar = true;
    private void Awake()
    {
        volume.profile.TryGet(out bloom);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && puedeUsar)
        {
            StartCoroutine(ActivarLuz());
        }
    }

    IEnumerator ActivarLuz()
    {
        puedeUsar = false;
        luz.gameObject.SetActive(true);
        Instantiate(ondaPrefab, transform.position, Quaternion.identity);
        float tiempo = 0f;
    

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            bloom.intensity.value = 5f;
            float pulso = Mathf.Sin(tiempo * 20f) * 0.5f + 0.5f;
            luz.intensity = Mathf.Lerp(1f, intensity, pulso);

            yield return null;
        }

        luz.intensity = 0f;
        bloom.intensity.value = 0f;
        luz.gameObject.SetActive (false);
        yield return new WaitForSeconds(coolDown);

        puedeUsar = true;
    }
}


