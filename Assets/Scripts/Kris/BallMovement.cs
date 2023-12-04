using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 10f;
    public float ballLift = 2f;
    private Rigidbody ballRB;
    private Vector3 startPos;
    public float reduceSpeed = 1f;
    public float reduceRotate = 1f;


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

        if(transform.position.y < 0.5f)
        {
            Vector3 reduceSpeedForce = -ballRB.velocity.normalized * reduceSpeed;
            ballRB.AddForce(reduceSpeedForce, ForceMode.Acceleration);

            Vector3 reduceRotateTorque = -ballRB.angularVelocity.normalized * reduceRotate;
            ballRB.AddTorque(reduceRotateTorque, ForceMode.Acceleration);
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
