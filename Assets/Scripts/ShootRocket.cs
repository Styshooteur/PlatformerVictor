using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootRocket : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}
