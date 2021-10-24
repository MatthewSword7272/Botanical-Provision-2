using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Normal Version");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void Quit()
    {
        Application.Quit(1);
    }

}

