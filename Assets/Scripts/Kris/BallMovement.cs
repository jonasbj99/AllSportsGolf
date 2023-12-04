using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 10f;
    public float ballLift = 2f;
    private Rigidbody ballRB;
    private Vector3 startPos;
    public float reduceSpeed = 5f;
    public float reduceRotate = 5f;


    // Start is called before the first frame update
    void Start()
    {
       startPos = transform.position;
       ballRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            ballRB.AddForce(Vector3.up * ballLift, ForceMode.Impulse);
            ballRB.AddForce(Vector3.forward * -ballSpeed, ForceMode.Impulse);
        }*/

        /*if(transform.position.y < 1)
        {
            
        }*/

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetToStartPosition();
        }

        if(transform.position.y < 0.5f && ballRB.velocity.magnitude > 0.4f)
        {
            Vector3 reduceSpeedForce = -ballRB.velocity.normalized * reduceSpeed;
            ballRB.AddForce(reduceSpeedForce, ForceMode.Acceleration);
        }

        if(ballRB.angularVelocity.magnitude > 0.4f)
        {
            Vector3 reduceRotateTorque = -ballRB.angularVelocity.normalized * reduceRotate;
            ballRB.AddTorque(reduceRotateTorque, ForceMode.Acceleration);
        }

        if(ballRB.velocity.magnitude < 0.5f)
        {
            ballRB.velocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;
        }
    }

    public void ResetToStartPosition()
    {
        transform.position = startPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClubHead"))
        {
            ballRB.AddForce(Vector3.up * ballLift, ForceMode.Impulse);
            //ballRB.AddForce(Vector3.forward * -ballSpeed, ForceMode.Impulse);
        }
    }

}
