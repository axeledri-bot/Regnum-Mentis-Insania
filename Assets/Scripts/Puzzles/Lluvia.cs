using UnityEngine;

public class Lluvia : MonoBehaviour
{
    [SerializeField] private Transform cam;
    private void LateUpdate()
    {
        transform.position = new Vector3(cam.position.x, cam.position.y + 10, 0);
    }
}
