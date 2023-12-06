using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] Transform ballTransform;

    void Update()
    {
        ballTransform = this.transform;
    }

    public void BallDestroy()
    {
        RigController.currentTransform.position = ballTransform.position;
        Destroy(this);
    }

    public void BallReset()
    {
        ballTransform.position = RigController.previousTransform.position;
    }
}
