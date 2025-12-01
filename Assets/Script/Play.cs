using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RumusBalok()
    {
        SceneManager.LoadScene("RumusBalok");
    }

    public void RumusBola()
    {
        SceneManager.LoadScene("RumusBola");
    }

    public void RumusKerucut()
    {
        SceneManager.LoadScene("RumusKerucut");
    }

    public void RumusKubus()
    {
        SceneManager.LoadScene("RumusKubus");
    }

    public void RumusTabung()
    {
        SceneManager.LoadScene("RumusTabung");
    }
}
