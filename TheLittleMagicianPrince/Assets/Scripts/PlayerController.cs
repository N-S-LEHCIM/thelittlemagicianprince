using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    [SerializeField] float _rotationSpeed;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] LayerMask _groundLayer;

    private Rigidbody rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
                //anim.SetTrigger("JUMP");
            }
        }
    }
    private void Movement()
    {
        float x = Input.GetAxis(HORIZONTAL_AXIS);
        float z = Input.GetAxis(VERTICAL_AXIS);

        Vector3 direction = new Vector3(x, 0, z);

        if (x != 0 || z != 0)
        {
            transform.forward = Vector3.Lerp(transform.forward, direction, _rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
        //anim.SetFloat("speed", direction.magnitude);
    }
    private void Jump()
    {
        Debug.Log("Deberia saltar");
        rb.AddForce(0, 1 * _jumpForce, 0);
    }
    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f, _groundLayer))
        {
            return true;
        }
        else return false;
    }
}
