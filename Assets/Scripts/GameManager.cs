using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hitScreen;
    [SerializeField] private GameObject musicManager;
    [FMODUnity.EventRef] [SerializeField] private string hitEvent = "";
    [FMODUnity.EventRef] [SerializeField] private string victoryEvent = "";
    
    public void GameOver()
    // The screen turns red each time you die cause of rockets or killing zone
    {
        FMODUnity.RuntimeManager.PlayOneShot(hitEvent, transform.position);
        var color = hitScreen.GetComponent<Image>().color;
        color.a = 0.8f;    
        hitScreen.GetComponent<Image>().color = color;
        SceneManager.LoadScene("GameScene");
    }

    private void Update()
    {
        if (hitScreen != null)
        {
            if (hitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = hitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                hitScreen.GetComponent<Image>().color = color;    
            }
        }
    }

    public void Victory()
    {
        Destroy(musicManager);
        FMODUnity.RuntimeManager.PlayOneShot(victoryEvent, transform.position);
        SceneManager.LoadScene("Victory");
    }
    
}


