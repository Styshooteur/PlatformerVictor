using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _hitScreen;
    public void GameOver()
    {
        var color = _hitScreen.GetComponent<Image>().color;
        color.a = 0.8f;    
        _hitScreen.GetComponent<Image>().color = color;
        SceneManager.LoadScene("GameScene");
    }

    private void Update()
    {
        if (_hitScreen != null)
        {
            if (_hitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = _hitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                _hitScreen.GetComponent<Image>().color = color;    
            }
        }
    }

    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }
    
}


