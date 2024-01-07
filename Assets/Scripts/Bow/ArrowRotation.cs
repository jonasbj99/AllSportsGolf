using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// YouTube videos by Sunny Valley Studio used for this script:
// https://youtube.com/playlist?list=PLcRSafycjWFf8ayYlaVYRFbVnoIcgVY3N&si=twTPm6S9rJ4rCshr

public class ArrowRotation : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    void FixedUpdate()
    {
        transform.forward = Vector3.Slerp(transform.forward, rb.velocity.normalized, Time.fixedDeltaTime);
    }
}
