using UnityEngine;

public class OndaLuz : MonoBehaviour
{
    public float velocidad = 4f;
    public float duracion = 0.4f;

    private float tiempo;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        float progreso = tiempo / duracion;

        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 4, progreso);

        Color c = sr.color;
        c.a = Mathf.Lerp(1f, 0f, progreso);
        sr.color = c;

        if (progreso >= 1f)
            Destroy(gameObject);
    }
}
