using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip popSound;
    public AudioClip deniedSound;

    public void PlayPop()
    {
        audioSource.PlayOneShot(popSound);
    }

    public void PlayDenied()
    {
        audioSource.PlayOneShot(deniedSound);
    }
}
