using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}