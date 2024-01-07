using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// YouTube videos by Sunny Valley Studio used for this script:
// https://youtube.com/playlist?list=PLcRSafycjWFf8ayYlaVYRFbVnoIcgVY3N&si=twTPm6S9rJ4rCshr

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

        Destroy(gameObject);
    }
}
