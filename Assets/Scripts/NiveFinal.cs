using UnityEngine;

public class Final : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.Stop("Latidos");
            FadeController.Instance.CambiarEscena("Menu");

        }
    }
}
