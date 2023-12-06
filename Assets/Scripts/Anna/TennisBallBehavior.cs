using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallBehavior : MonoBehaviour
{
    [SerializeField] Transform ballSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tennisBall = this.gameObject;
            Rigidbody tennisRB =  tennisBall.GetComponent<Rigidbody>();

            tennisBall.transform.position = ballSpawn.position;
            tennisRB.velocity = Vector3.zero;
            tennisRB.angularVelocity = Vector3.zero;
        }
    }
}
