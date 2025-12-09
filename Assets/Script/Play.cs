using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public float fadeDuration = 0.5f; 

    void Start()
    {
        // Matikan BGM utama saat masuk Play
        AudioManager.Instance.StopBGM();
    }

    public void MainMenu()
    {
        AudioManager.Instance.PlayBackClick();
        StartCoroutine(FadeAndLoad("MainMenu"));
    }

    public void RumusBalok()
    {
        AudioManager.Instance.PlayButtonClick();
        StartCoroutine(FadeAndLoad("RumusBalok"));
    }

    public void RumusBola()
    {
        AudioManager.Instance.PlayButtonClick();
        StartCoroutine(FadeAndLoad("RumusBola"));
    }

    public void RumusKerucut()
    {
        AudioManager.Instance.PlayButtonClick();
        StartCoroutine(FadeAndLoad("RumusKerucut"));
    }

    public void RumusKubus()
    {
        AudioManager.Instance.PlayButtonClick();
        StartCoroutine(FadeAndLoad("RumusKubus"));
    }

    public void RumusTabung()
    {
        AudioManager.Instance.PlayButtonClick();
        StartCoroutine(FadeAndLoad("RumusTabung"));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        // 🔥 Matikan ARSoundHandler sebelum pindah scene
        foreach (var handler in FindObjectsOfType<ARSoundHandler>())
        {
            handler.enabled = false;
        }

        // Ambil semua audio source
        var audioSources = FindObjectsOfType<AudioSource>();
        int n = audioSources.Length;
        float[] startVolumes = new float[n];
        for (int i = 0; i < n; i++) 
            startVolumes[i] = audioSources[i].volume;

        // Fade out audio
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            float f = 1f - Mathf.Clamp01(t / fadeDuration);

            for (int i = 0; i < n; i++)
                audioSources[i].volume = startVolumes[i] * f;

            yield return null;
        }

        // Stop audio
        for (int i = 0; i < n; i++)
        {
            if (audioSources[i].isPlaying)
                audioSources[i].Stop();

            audioSources[i].volume = startVolumes[i]; 
        }

        // Load scene
        SceneManager.LoadScene(sceneName);
    }
}
