using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;
    [SerializeField] private float horsePower = 10f;
    [SerializeField] private float turnSpeed = 10;

    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveCar();
    }
    private void MoveCar()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput, ForceMode.Acceleration);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
