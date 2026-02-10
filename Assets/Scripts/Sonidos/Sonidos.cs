using UnityEngine;

[System.Serializable]
public class Sonidos
{
    public string nombre;

    public AudioClip audio;

    public bool loop;

    [Range(0,1)]
    public float volume;

    [HideInInspector]
    public AudioSource audioSource;
}
