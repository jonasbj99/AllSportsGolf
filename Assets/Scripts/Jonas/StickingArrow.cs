using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingArrow : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject stuckArrow;
    [SerializeField] SphereCollider arrowCollider;

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        arrowCollider.isTrigger = true;

        GameObject arrow = Instantiate(stuckArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        // If target = destroy target
    }
}
