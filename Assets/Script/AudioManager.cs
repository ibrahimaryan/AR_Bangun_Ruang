using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;   // untuk pop, denied, button click
    public AudioSource bgmSource;   // untuk background music

    [Header("SFX Clips")]
    public AudioClip popSound;
    public AudioClip deniedSound;
    public AudioClip buttonClick;
    public AudioClip backClick;

    [Header("BGM Clips")]
    public AudioClip mainMenuTheme;

    private void Awake()
    {
        // Singleton: pastikan hanya ada 1 AudioManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // tetap hidup di semua scene
        }
        else
        {
            Destroy(gameObject); // hancurkan duplikat jika ada
        }
    }

    // =====================
    //   SFX FUNCTION
    // =====================
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayPop()
    {
        PlaySFX(popSound);
    }

    public void PlayDenied()
    {
        PlaySFX(deniedSound);
    }

    public void PlayButtonClick()
    {
        PlaySFX(buttonClick);
    }

    public void PlayBackClick()
    {
        PlaySFX(backClick);
    }

    // =====================
    //   BGM FUNCTION
    // =====================
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip && bgmSource.isPlaying)
            return; // jika musik sudah jalan, tidak restart ulang

        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
