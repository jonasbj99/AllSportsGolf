using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 10f;
    public float ballLift = 2f;
    private Rigidbody ballRB;

    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
       startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ballRB.AddForce(Vector3.up * ballLift, ForceMode.Impulse);
            ballRB.AddForce(Vector3.forward * -ballSpeed, ForceMode.Impulse);
        }

        /*if(transform.position.y < 1)
        {
            
        }*/

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClubHead"))
        {
            ballRB.AddForce(Vector3.up * ballLift, ForceMode.Impulse);
            ballRB.AddForce(Vector3.forward * -ballSpeed, ForceMode.Impulse);
        }
    }

}
