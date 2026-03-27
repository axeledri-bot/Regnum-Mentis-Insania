using UnityEngine;

public class Final : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

            FadeController.Instance.CambiarEscena("Menu");

        }
    }
}
