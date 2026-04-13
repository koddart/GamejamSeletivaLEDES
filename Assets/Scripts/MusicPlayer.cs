using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource musicSource;

    public void PlayMusic()
    {
        musicSource.loop = true;
        musicSource.Play();
    }
}