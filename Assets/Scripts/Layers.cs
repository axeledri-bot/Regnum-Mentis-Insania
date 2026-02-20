using UnityEngine;
using UnityEngine.Tilemaps;

public class Layers : MonoBehaviour
{
    private SpriteRenderer sr;
    private TilemapRenderer mr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        mr = GetComponent<TilemapRenderer>();
    }
    
    void LateUpdate()
    {
        if (sr != null)
        {
            sr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
        else
        {
            mr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
    }
}
 
