using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] Transform ballTransform;

    bool outOfBounds;

    public void BallDestroy()
    {
        if (outOfBounds == false)
        {
            RigController.playerTransform.position = ballTransform.position;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OutOfBounds"))
        {
            outOfBounds = true;
        }
        else
        {
            outOfBounds = false;
        }
    }
}
