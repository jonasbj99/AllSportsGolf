using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] Transform ballTransform;

    public void BallDestroy()
    {
        RigController.playerTransform.position = ballTransform.position;
        Destroy(this.gameObject);
    }

    public void StopKinematic()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<XRGrabInteractable>().throwOnDetach = true;
    }
}
