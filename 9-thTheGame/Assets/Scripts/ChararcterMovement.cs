using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChararcterMovement : MonoBehaviour
{
    public CharacterController _controller;
    public Transform _groundCheck;
    public LayerMask _groundMasc;

    public float mSpeed = 8f;
    public float gravity = -19.62f;
    public float grDistance = 0.4f;
    public float jHeight = 1.5f;
    public float rSpeed = 300f;

    Vector3 _velocity;

    bool isGrounded;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRuning", false);
    }
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, grDistance, _groundMasc);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mx = Input.GetAxis("Mouse X");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * mSpeed * Time.deltaTime);

        if (mx != 0)
        {
            transform.Rotate(transform.up * mx * rSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jHeight * -2f * gravity);
        }
        _velocity.y += gravity * Time.deltaTime;
        
        bool hasHorizontalInput = !Mathf.Approximately(x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(z, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        anim.SetBool("isRuning", isWalking);
        
      
        _controller.Move(_velocity * Time.deltaTime);
    }
}
