using UnityEngine;
using Vuforia;

public class ARSoundHandler : MonoBehaviour
{
    public AudioManager audioManager;
    private ObserverBehaviour observer;

    void OnEnable()
    {
        observer = observer ?? GetComponent<ObserverBehaviour>();
        if (observer)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;

        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>();
    }

    void OnDisable()
    {
        if (observer != null)
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    void OnDestroy()
    {
        if (observer != null)
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (audioManager == null)
        {
            Debug.LogWarning("ARSoundHandler: AudioManager null, melewatkan pemutaran suara.");
            return;
        }

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
            audioManager.PlayPop();
        else
            audioManager.PlayDenied();
    }
}
