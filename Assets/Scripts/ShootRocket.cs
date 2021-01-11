using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using UnityEngine. SceneManagement;


public class ShootRocket : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    private Rigidbody2D rb;
    private float _spawnFrequency = 0.0f;




    void Start()
    
    // A random frequency of rocket launch is generated each time you restart the level
    {
        _spawnFrequency = Random.Range(10, 20);

        if (projectile != null)
        {
            InvokeRepeating("SpawnRocket", 2f, _spawnFrequency);
        }
    }
    

    /*private void GenerateRandomInterval()
    {
        _spawnFrequency = Time.time;
        float randomNum = Random.Range(1, 15);
        _spawnFrequency = randomNum;
    }*/
    

    void SpawnRocket()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}