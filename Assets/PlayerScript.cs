using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody RB;
    private Vector2 Mov;
    private bool Jump;
    public float RotateSpeed;
    public float JumpForce;
    private Collider col;
    private float distToGround;
    public float TimerPulo;
    private float _TimerPulo;
    public int Pontos;
    public float SpeedSprint;
    private bool _Sprinting;
    private Animator Anim;
    private Variables v;
    public TextMeshProUGUI txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        distToGround = col.bounds.extents.y;
        _TimerPulo = TimerPulo;
        v = Variables.Instance;
        v.InMatch = true;
    }

    public void ForcedJump()
    {
        RB.AddForce(Vector3.up * JumpForce * 0.7f, ForceMode.Impulse);
        Jump = false;
        _TimerPulo = TimerPulo;
    }

    public void OnMove(InputValue e)
    {
        Mov = e.Get<Vector2>();
        Anim.SetBool("Walking", true);
    }

    public void OnSprint(InputValue e)
    {
        _Sprinting = e.isPressed;
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

        if (_Sprinting)
        {
            velocity.x = Mov.x * SpeedSprint;
        }
        else
        {
            velocity.x = Mov.x * Speed;
        }
        
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
        if (velocity.x > 0)
        {
            Quaternion targetRotation = Quaternion.Euler(0, -260, 0);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                RotateSpeed * Time.deltaTime
            );
        }
        else if (velocity.x < 0)
        {
            Quaternion targetRotation = Quaternion.Euler(0, -90, 0);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                RotateSpeed * Time.deltaTime
            );
        }
        else
        {
            Anim.SetBool("Walking", false);
        }//TODO
        txt.text = "Tempo: " + v.Tempo.ToString();//object reference not set to a reference of a object??
        Debug.Log("Tempo" + v.Tempo.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(Pontos <= 0)
            {
                Debug.Log("MORREU");
            }
            else
            {
                Pontos--;
                Destroy(collision.gameObject);
            }
        }
    }
}
