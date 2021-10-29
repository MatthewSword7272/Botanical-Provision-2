using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public static bool HowToPlayBool = false;
    public GameObject pauseMenuUI;
    public GameObject HowtoPlayUI;
    private AudioSource gameMusic;
    public GameObject Reticle;
    public GameObject CancelUI;

    // Update is called once per frame
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        HowtoPlayUI.SetActive(false);
        gameMusic = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        Reticle = GameObject.Find("Reticle");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        CancelUI.SetActive(true);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Reticle.SetActive(true);
        gameMusic.UnPause();

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        CancelUI.SetActive(false);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Reticle.SetActive(false);
        gameMusic.Pause();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Screen");
    }

    public void LoadTutorial()
    {
        if (HowToPlayBool)
        {
            HowtoPlayUI.SetActive(false);
            HowToPlayBool = false;
        }
        else
        {
            HowtoPlayUI.SetActive(true);
            HowToPlayBool = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit(1);
    }
}
