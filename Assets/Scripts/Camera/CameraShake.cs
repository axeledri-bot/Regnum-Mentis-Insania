using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private CinemachineImpulseSource impulse;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        impulse = GetComponent<CinemachineImpulseSource>();
    }
   
    public void Shake(float fuerza = 1f)
    {
        Debug.Log("SHAKE LLAMADO: " + fuerza);
        impulse.GenerateImpulse(fuerza);
    }
}
