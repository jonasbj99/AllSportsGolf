using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 10f;
    public float ballLift = 2f;
    public float ballSpeedMultiplier = 10f;
    private Rigidbody ballRB;
    public Rigidbody clubRB;
    private Vector3 startPos;
    private Vector3 currentPos;
    public float reduceSpeed = 5f;
    public float reduceRotate = 5f;


    // Start is called before the first frame update
    void Start()
    {
       startPos = transform.position;
       ballRB = GetComponent<Rigidbody>();
       clubRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            ballRB.AddForce(Vector3.up * ballLift, ForceMode.Impulse);
            ballRB.AddForce(Vector3.forward * -ballSpeed, ForceMode.Impulse);
        }*/

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Only for testing
            ResetToStartPosition();
        }

        if(transform.position.y < 0.5f && ballRB.velocity.magnitude > 0.4f)
        {
            // Slows down speed of ball if ball is lower than 0.5f on y-axis and if the speed of the ball is more than 0.4f
            Vector3 reduceSpeedForce = -ballRB.velocity.normalized * reduceSpeed;
            ballRB.AddForce(reduceSpeedForce, ForceMode.Acceleration);
        }

        if(ballRB.angularVelocity.magnitude > 0.4f)
        {
            // Decreases rotation if ball is rotating faster than 0.4f
            Vector3 reduceRotateTorque = -ballRB.angularVelocity.normalized * reduceRotate;
            ballRB.AddTorque(reduceRotateTorque, ForceMode.Acceleration);
        }

        if(ballRB.velocity.magnitude < 0.5f)
        {
            // Stops the ball completely (both speed and rotation) after its speed goes below 0.5f
            ballRB.velocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;

            
        }
        // virker ikke som det skal
        if(ballRB.velocity.magnitude !> 0 && currentPos != startPos)
        {
            MeasureDistanceOfBall();
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
            float newBallSpeed = ballSpeed * clubRB.GetComponent<Rigidbody>().velocity.magnitude * ballSpeedMultiplier;

            // Add force in the direction of the side of the collider with adjusted speed
            ballRB.AddForce(colliderDirection * newBallSpeed, ForceMode.Impulse);

            ballRB.AddForce(Vector3.up * ballLift, ForceMode.Impulse);


            //ballRB.AddForce(Vector3.forward * -ballSpeed, ForceMode.Impulse);

            // Measures speed added to ball when hit be the golf club
            Debug.Log("Ball speed: " + newBallSpeed);
            
        }
    }

    private void MeasureDistanceOfBall()
    {
        // Measures distance from start position to current position of the ball
        float dist = Vector3.Distance(startPos, currentPos);
        Debug.Log("Distance " + dist);
    }

}
