using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [FMODUnity.EventRef] [SerializeField] private string menuEvent = "";
    
    private static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    
    // Update is called once per frame
    void Update()
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
        FMODUnity.RuntimeManager.PlayOneShot(menuEvent, transform.position);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        FMODUnity.RuntimeManager.PlayOneShot(menuEvent, transform.position);
        Application.Quit();
    }
}
