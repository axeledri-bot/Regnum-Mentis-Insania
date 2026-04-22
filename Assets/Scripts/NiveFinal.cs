using UnityEngine;

public class Final : MonoBehaviour
{
    [SerializeField] private string nivel;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.Stop("Latidos");
            FadeController.Instance.CambiarEscena(nivel);

        }
    }
}
