using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public float fadeDuration = 0.5f; // durasi fade out dalam detik

    public void MainMenu()
    {
        StartCoroutine(FadeAndLoad("MainMenu"));
    }

    public void RumusBalok()
    {
        StartCoroutine(FadeAndLoad("RumusBalok"));
    }

    public void RumusBola()
    {
        StartCoroutine(FadeAndLoad("RumusBola"));
    }

    public void RumusKerucut()
    {
        StartCoroutine(FadeAndLoad("RumusKerucut"));
    }

    public void RumusKubus()
    {
        StartCoroutine(FadeAndLoad("RumusKubus"));
    }

    public void RumusTabung()
    {
        StartCoroutine(FadeAndLoad("RumusTabung"));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        var audioSources = FindObjectsOfType<AudioSource>();
        int n = audioSources.Length;
        float[] startVolumes = new float[n];
        for (int i = 0; i < n; i++) startVolumes[i] = audioSources[i].volume;

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime; // gunakan unscaled agar UI tetap responsif saat timeScale berubah
            float f = 1f - Mathf.Clamp01(t / fadeDuration);
            for (int i = 0; i < n; i++)
                audioSources[i].volume = startVolumes[i] * f;
            yield return null;
        }

        // hentikan audio (opsional)
        for (int i = 0; i < n; i++)
        {
            if (audioSources[i].isPlaying) audioSources[i].Stop();
            audioSources[i].volume = startVolumes[i]; // kembalikan volume default jika diperlukan
        }

        SceneManager.LoadScene(sceneName);
    }
}
