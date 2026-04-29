using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody RB;
    private Vector2 Mov;
    private bool Jump;
    public float JumpForce;
    private Collider col;
    private float distToGround;
    public float TimerPulo;
    private float _TimerPulo;
    public int Pontos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        distToGround = col.bounds.extents.y;
        _TimerPulo = TimerPulo;
    }

    public void OnMove(InputValue e)
    {
        Mov = e.Get<Vector2>();
    }

    public void OnJump(InputValue e)
    {
        Jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool IsGrounded()
    {
         return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

private void FixedUpdate()
    {
        Vector3 velocity = RB.linearVelocity;

        velocity.x = Mov.x * Speed;

        RB.linearVelocity = velocity;

        if (Jump && IsGrounded() && _TimerPulo < 0)
        {
            RB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Jump = false;
            _TimerPulo = TimerPulo;
        }
        else
        {
            Jump = false;
        }

        if (IsGrounded())
        {
            _TimerPulo -= Time.deltaTime;
        }
    }
}
