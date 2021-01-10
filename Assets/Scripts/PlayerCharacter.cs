using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    private enum State
    {
        None,
        Idle,
        Walk,
        Jump
    }

    private State _currentState = State.None;

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private PlayerFoot foot;
    [SerializeField] private GameManager gameManager;
    

    [FMODUnity.EventRef] [SerializeField] private string jumpEvent = "";


    private const float DeadZone = 0.1f;
    private const float MoveSpeed = 4.0f;
    private const float JumpSpeed = 12.0f;
    private const float BumpForce = 28.0f;

    private bool _facingRight = true;
    private bool _jumpButtonDown = false;

    void Start()
    {
        ChangeState(State.Jump);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumpButtonDown = true;
        }
    }

    void FixedUpdate()
    {
        /*float moveDir = 0.0f;
        if (Input.GetButtonDown("Left"))
        {
            moveDir -= 1.0f;
        }
        if (Input.GetButtonDown("Right"))
        {
            moveDir += 1.0f;
        }*/

        if (foot.FootContact_ > 0 && _jumpButtonDown)
        {
            Jump();
        }
        _jumpButtonDown = false;

        var vel = body.velocity;
        body.velocity = new Vector2(MoveSpeed * Input.GetAxis("Horizontal"), vel.y);
        //We flip the characters when not facing in the right direction
        if (Input.GetAxis("Horizontal") > DeadZone && !_facingRight)
        {
            Flip();
        }

        if (Input.GetAxis("Horizontal") < -DeadZone && _facingRight)
        {
            Flip();
        }
        //We manage the state machine of the character
        switch (_currentState)
        {
            case State.Idle:
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone)
                {
                    ChangeState(State.Walk);
                }

                if (foot.FootContact_ == 0)
                {
                    ChangeState(State.Jump);
                }
                break;
            case State.Walk:
                if (Mathf.Abs(Input.GetAxis("Horizontal")) < DeadZone)
                {
                    ChangeState(State.Idle);
                }

                if (foot.FootContact_ == 0)
                {
                    ChangeState(State.Jump);
                }
                break;
            case State.Jump:
                if (foot.FootContact_ > 0)
                {
                    ChangeState(State.Idle);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }

    private void Jump()
    {
        FMODUnity.RuntimeManager.PlayOneShot(jumpEvent, transform.position);
        var vel = body.velocity;
        body.velocity = new Vector2(vel.x, JumpSpeed);
    }

    void ChangeState(State state)
    {
        switch (state)
        {
            case State.Idle:
                anim.Play("Idle");
                break;
            case State.Walk:
                anim.Play("Walk");
                break;
            case State.Jump:
                anim.Play("Jump");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }

        _currentState = state;
    }

    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        _facingRight = !_facingRight;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("KillingZone"))
        {
            gameManager.GameOver();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Bumper"))
        {
            body.AddForce(transform.up * BumpForce, ForceMode2D.Impulse);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Rocket"))
        {
            gameManager.GameOver();
        }
        
        if (other.gameObject.layer == LayerMask.NameToLayer("EndRobot"))
        {
            gameManager.Victory();
        }
    }
    
}
