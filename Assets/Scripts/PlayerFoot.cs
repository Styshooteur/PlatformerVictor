using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class PlayerFoot : MonoBehaviour
{
    private int _footContact = 0;

    public int FootContact_ => _footContact;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            _footContact++;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Camera Foot"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            _footContact--;
        }
    }
}
