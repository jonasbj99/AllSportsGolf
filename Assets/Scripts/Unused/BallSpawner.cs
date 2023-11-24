using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject instBall;
    public GameObject kineBall;
    public GameObject veloBall;

    public Transform instPos;
    public Transform kinePos;
    public Transform veloPos;

    public void SpawnBallInst()
    {
        Instantiate(instBall, instPos);
    }

    public void SpawnBallKine()
    {
        Instantiate(kineBall, kinePos);
    }

    public void SpawnBallVelo()
    {
        Instantiate(veloBall, veloPos);
    }
}
