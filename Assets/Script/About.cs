using UnityEngine;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
    void Start()
    {
        // Tetap mainkan BGM main menu
        AudioManager.Instance.PlayBGM(AudioManager.Instance.mainMenuTheme);
    }

    public void Back()
    {
        AudioManager.Instance.PlayBackClick();
        SceneManager.LoadScene("MainMenu");
    }
}
