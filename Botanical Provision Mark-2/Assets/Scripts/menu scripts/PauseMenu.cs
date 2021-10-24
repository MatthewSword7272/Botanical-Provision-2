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

    //use these for the button overlap
  //  private Interactable interactable;
    private bool pickupSwitch = false;

    private AudioSource gameMusic;
    public GameObject Reticle;

    // Update is called once per frame
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        HowtoPlayUI.SetActive(false);
     //   interactable = FindObjectOfType<Interactable>();
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
