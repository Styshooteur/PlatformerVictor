using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;

    private const float MoveSpeed = 1.5f;
    
    // The camera is moving upwards at a constant speed allover the game
    private void Move()
    {
        var vel = body.velocity;
        body.velocity = new Vector2(vel.x, MoveSpeed);
    }

    private void Start()
    {
        Move();
    }
    
}
