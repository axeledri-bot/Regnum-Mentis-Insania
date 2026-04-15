using UnityEngine;

public class GuardarCargar : MonoBehaviour
{
    private PlayerData playerData;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            SistemaDeGuardado.Guardar();
        }

        if(Input.GetKeyDown(KeyCode.F6))
        {
            playerData = SistemaDeGuardado.Cargar();
            GameManager.instance.vidas = playerData.vida;
        }
    }
}
