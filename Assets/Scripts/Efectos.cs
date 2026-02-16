using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Efectos : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private Vignette vignette;
    private ChromaticAberration chroma;
    private DepthOfField dof;

    void Start()
    {
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chroma);
        volume.profile.TryGet(out dof);

        Desactivar();
    }

    public void Activar()
    {
        vignette.intensity.value = 0.4f;
        chroma.intensity.value = 0.3f;
        dof.active = true;
    }

    public void Desactivar()
    {
        vignette.intensity.value = 0f;
        chroma.intensity.value = 0f;
        dof.active = false;
    }
}