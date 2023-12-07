using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallBehavior : MonoBehaviour
{
    //private Rigidbody ballRB;
    //private float reduceBallSpeed = 5f;
    [SerializeField] Transform ballTransform;

    bool outOfBounds;

    /*void Start()
    {
        ballRB = GetComponent<Rigidbody>();
    }

   void Update()
    {
        if(ballRB.velocity.magnitude > 0.4f)
        {
            Vector3 reduceSpeedForce = -ballRB.velocity.normalized * reduceBallSpeed;
            ballRB.AddForce(reduceSpeedForce, ForceMode.Acceleration);
            ballRB.velocity = Vector3.zero;
        }
    }
    */

    public void BallDestroy()
    {
        RigController.playerTransform.position = ballTransform.position;
        Destroy(this.gameObject);
    }

 
}
