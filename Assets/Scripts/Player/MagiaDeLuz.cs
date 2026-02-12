using UnityEngine;

public class MagiaDeLuz : MonoBehaviour
{


    private Enemy mEnemy;
    void Start()
    {
        mEnemy  = FindFirstObjectByType<Enemy>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)) 
        {
            mEnemy.aturdido = true;
        }
    }
}
