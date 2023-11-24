using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Table" && collision.gameObject.tag != "Ball")
        {
            Destroy(this.gameObject, 3f);
        }
    }
}
