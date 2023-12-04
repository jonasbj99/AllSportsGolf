using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisCapsuleFollower : MonoBehaviour
{
    private TennisCapsule _tennisFollower;
    //Rigidbody og Vector3 skal være blå ligesom Tenniscollider over
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    [SerializeField]
    private float _sensitivity = 100f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 destination = _tennisFollower.transform.position;
        _rigidbody.transform.rotation = transform.rotation;

        _velocity = (destination - _rigidbody.transform.position) * _sensitivity;

        _rigidbody.velocity = _velocity;
        transform.rotation = _tennisFollower.transform.rotation;
    }

    public void SetFollowTarget(TennisCapsule tennisFollower)
    {
        _tennisFollower = tennisFollower;
    }
}
   
