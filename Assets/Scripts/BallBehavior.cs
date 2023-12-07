using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] Transform ballTransform;

    public void BallDestroy()
    {
        RigController.playerTransform.position = ballTransform.position;
        Destroy(this.gameObject);
    }
}
