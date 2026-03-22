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
    [SerializeField] private GameObject fade;

    private bool modoCinematico = false;
    private bool luzPermanente = false;

    private void Awake()
    {
        volume.profile.TryGet(out bloom);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && puedeUsar && !modoCinematico && !luzPermanente)
        {
            StartCoroutine(ActivarLuz());
        }
    }

    IEnumerator ActivarLuz()
    {
        AudioManager.instance.Play("Daños Luz");
        puedeUsar = false;
        fade.SetActive(true);
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

        fade.SetActive(false);
        puedeUsar = true;
    }
    public IEnumerator SecuenciaLuzCinematica()
    {
        modoCinematico = true;
        puedeUsar = false;

        luz.gameObject.SetActive(true);
        fade.SetActive(true);

        float tiempo = 0f;


        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime;
            luz.intensity = Mathf.Lerp(0f, 0.5f, tiempo);
            bloom.intensity.value = Mathf.Lerp(0f, 1f, tiempo);
            yield return null;
        }
        AudioManager.instance.Play("Daños Luz");

        Instantiate(ondaPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);


        tiempo = 0f;
        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime;

            float pulso = Mathf.Sin(Time.time * 15f) * 0.3f;

            luz.intensity = Mathf.Lerp(0.5f, 1.5f, tiempo) + pulso;
            bloom.intensity.value = Mathf.Lerp(1f, 3f, tiempo);

            yield return null;
        }
        AudioManager.instance.Play("Daños Luz");
        Instantiate(ondaPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.3f);


        luz.intensity = 3f;
        bloom.intensity.value = 6f;

        yield return new WaitForSeconds(0.2f);


        luz.intensity = 2f;
        bloom.intensity.value = 1.5f;
        AudioManager.instance.Play("Daños Luz");


        fade.SetActive(false);

        luzPermanente = true;

        modoCinematico = false;

    }
}


