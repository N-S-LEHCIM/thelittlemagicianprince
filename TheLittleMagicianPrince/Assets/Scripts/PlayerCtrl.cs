using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _cam;
    [SerializeField] private Animator _animator;
    private float distanceToGround;

    private float _groundCheckRadius = 0.3f;
    private float _speed = 8;
    private float _turnSpeed = 1500f;
    private float _jumpForce = 500f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private GravityBody _gravityBody;

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        _animator.SetBool("isRun", false);
    }

    private bool isGrounded()
    {
       return Physics.BoxCast(transform.position, new Vector3(0.4f, 0f, 0.4f), Vector3.down, Quaternion.identity, distanceToGround + 0.1f);
    }

    void Update()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        //bool isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        //_animator.SetBool("isJumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
            _rigidbody.AddForce(-_gravityBody.GravityDirection * _jumpForce, ForceMode.Impulse);
        }
        //Move();
    }


    void FixedUpdate()
    {
        bool isRunning = _direction.magnitude > 0.1f;

       if (isRunning)
       {
           Vector3 direction = transform.forward * _direction.z;
           _rigidbody.MovePosition(_rigidbody.position + direction * (_speed * Time.fixedDeltaTime));

           Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (_turnSpeed * Time.fixedDeltaTime), 0f);
           Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, _rigidbody.rotation * rightDirection, Time.fixedDeltaTime * 3f); ;
           _rigidbody.MoveRotation(newRotation);
           _animator.SetBool("isRun", isRunning);
       }

        _animator.SetBool("isRun", isRunning);
    }
    private void Jump()
    {
        _rigidbody.AddForce(0, _jumpForce, 0);
    }
    //private void Move()
    //{
    //    float ejeHorizontal = Input.GetAxis("Horizontal");
    //    float ejeVertical = Input.GetAxis("Vertical");

    //    if (ejeHorizontal != 0 || ejeVertical != 0)
    //    {
    //        _animator.SetBool("isRun", true);
    //        Vector3 direction = new Vector3(ejeHorizontal, 0, ejeVertical);
    //        transform.Translate(_speed * Time.deltaTime * direction);

    //        //if (!audioPlayer.isPlaying)
    //        //{
    //        //    audioPlayer.PlayOneShot(walkSound, 0.5f);
    //        //    //audioPlayer.Play();
    //        //}

    //        //audioPlayer.PlayOneShot(walkSound, 0.5f);
    //    }
    //    else
    //    {
    //        _animator.SetBool("isRun", false);
    //        //audioPlayer.Stop();
    //    }
    //}
}
