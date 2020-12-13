using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class PlayerFoot : MonoBehaviour
{
    [SerializeField] public Rigidbody2D body;
    
    public int footContact = 0;
    private const float BumpForce = 30.0f;
    
    public int FootContact_ => footContact;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            footContact++;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Camera Foot"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Bumper"))
        {
            footContact++;
            body.AddForce(transform.up * BumpForce, ForceMode2D.Impulse);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            footContact--;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Bumper"))
        {
            footContact--;
        }
    }
    
}
