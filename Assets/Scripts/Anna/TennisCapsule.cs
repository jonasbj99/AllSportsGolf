using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisCapsule : MonoBehaviour
{
    ////https://www.youtube.com/watch?v=j19QDOn2cCc used for inspiration

    [SerializeField]
    private TennisCapsuleFollower _tennisCapsuleFollowerPrefab;

    private void SpawnTennisCapsuleFollower()
    {
        var follower = Instantiate(_tennisCapsuleFollowerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }

    private void Start()
    {
        SpawnTennisCapsuleFollower();
    }


}
