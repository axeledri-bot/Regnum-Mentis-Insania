using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sonidos[] sonidos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        foreach(Sonidos s in sonidos)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.clip = s.audio;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volume;
        }
    }
    public void Play(string name)
    {
        foreach(Sonidos s in sonidos)
        {
            if(name == s.nombre)
            {
                s.audioSource.Play();
                return;
            }
        }
        Debug.Log("No existe");
    }public void Stop(string name)
    {
        foreach(Sonidos s in sonidos)
        {
            if(name == s.nombre)
            {
                s.audioSource.Stop();
                return;
            }
        }
        Debug.Log("No existe");
    }
}
