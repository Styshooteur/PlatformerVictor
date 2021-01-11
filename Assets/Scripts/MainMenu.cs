using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class MainMenu : MonoBehaviour
{
    [FMODUnity.EventRef] [SerializeField] private string menuEvent = "";
    [FMODUnity.EventRef] [SerializeField] private string musicEvent = "";
    
    public void PlayGame()
    {
        FMODUnity.RuntimeManager.PlayOneShot(menuEvent, transform.position);
        SceneManager.LoadScene("IntroScene");
    }

    public void QuitGame()
    {
        FMODUnity.RuntimeManager.PlayOneShot(menuEvent, transform.position);
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void PlayLevel()
    {
        FMODUnity.RuntimeManager.PlayOneShot(menuEvent, transform.position);
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        FMODUnity.RuntimeManager.PlayOneShot(menuEvent, transform.position);
        SceneManager.LoadScene("Menu");
    }
}
