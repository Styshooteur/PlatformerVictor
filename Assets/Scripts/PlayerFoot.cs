using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class PlayerFoot : MonoBehaviour
{
    private int footContact_ = 0;

    public int FootContact => footContact_;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            footContact_++;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Camera Foot"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Bumper"))
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            footContact_--;
        }
    }
}
