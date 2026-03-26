using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string Musica;
    [SerializeField] private string Efecto;
    void Start()
    {
        AudioManager.instance.Play(Musica);
        AudioManager.instance.Play(Efecto);
    }

}
