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
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClubHead"))
        {
            // Get the impact point in world space
            Vector3 colliderImpact = other.ClosestPointOnBounds(transform.position);

            // Calculate the direction from the collider's center to the impact point
            Vector3 directionImpact = (colliderImpact - other.transform.position).normalized;

            // Calculate the angle between the collider's forward direction and the direction to the impact point
            float angle = Vector3.Angle(other.transform.forward, directionImpact);

            // Determine the axis of rotation from the collider's forward to the direction to the impact point
            Vector3 rotationAxis = Vector3.Cross(other.transform.forward, directionImpact).normalized;

            // Use the angle and axis to create a rotation quaternion
            Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);

            // Get the rotated forward direction (side of the collider)
            Vector3 colliderDirection = rotation * other.transform.forward;

            // Adjust ballSpeed based on the velocity of the golf club's swing
            float newBallSpeed = ballSpeed * other.GetComponent<Rigidbody>().velocity.magnitude;

            // Add force in the direction of the side of the collider with adjusted speed
            ballRB.AddForce(colliderDirection * newBallSpeed, ForceMode.Impulse);

            ballRB.AddForce(Vector3.up * ballLift, ForceMode.Impulse);


            //ballRB.AddForce(Vector3.forward * -ballSpeed, ForceMode.Impulse);
        }
    }

}
