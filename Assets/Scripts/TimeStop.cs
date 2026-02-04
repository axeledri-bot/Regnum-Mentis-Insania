using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;
        }

    }
}
