using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class RocketDamage : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody == player.GetComponent<Rigidbody2D>())
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
