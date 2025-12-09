using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RumusBack : MonoBehaviour
{
    public void Back()
    {
        AudioManager.Instance.PlayBackClick();
        SceneManager.LoadScene("Play");
    }
}
