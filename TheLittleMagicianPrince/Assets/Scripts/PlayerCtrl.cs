using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private int lifePlayer = 100;
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
    private InventoryManager _inventory;

    //EVENTS
    public static event Action onDeath;
    public static event Action<int> onLifes;
    void Start()
    { 
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
        _animator.SetBool("isRun", false);
        _inventory = GetComponent<InventoryManager>();
        onLifes?.Invoke(lifePlayer); //NUMERO DE VIDAS DEL PLAYER
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
        if (Input.GetKeyUp(KeyCode.F))
        {
            UseItem();
        }
        
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
        _animator.SetTrigger("isJump");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            GameObject food = other.gameObject;
            food.SetActive(false);
            _inventory.AddInventoryOne(food.name, food);
            _inventory.SeeInventoryOne();
            _inventory.CountFood(food);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifePlayer--;
            Destroy(collision.gameObject);
            onLifes?.Invoke(lifePlayer); //NUMERO DE VIDAS DEL PLAYER
            if (lifePlayer == 0)
            {
                //Debug.Log("GAME OVER");
                //onDeath();
                onDeath?.Invoke();
            }
        }
    }
        private void UseItem()
    {
        GameObject food = _inventory.GetInventoryOne();
        food.SetActive(true);
        food.transform.position = transform.position + new Vector3(1f, 1f, 1f);
    }

}
