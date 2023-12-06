using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    void FixedUpdate()
    {
        transform.forward = Vector3.Slerp(transform.forward, rb.velocity.normalized, Time.fixedDeltaTime);
    }
}
