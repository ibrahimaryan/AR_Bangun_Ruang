using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Putar BGM main menu
        AudioManager.Instance.PlayBGM(AudioManager.Instance.mainMenuTheme);
    }

    public void Exit()
    {
        AudioManager.Instance.PlayBackClick();
        Application.Quit();
        Debug.Log("Game Telah Keluar");
    }

    public void About()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene("About");
    }

    public void Play()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene("Play");
    }
}
