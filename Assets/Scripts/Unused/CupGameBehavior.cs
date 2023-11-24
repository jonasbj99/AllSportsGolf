using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGameBehavior : MonoBehaviour
{
    public static float cupScore;

    void Start()
    {
        cupScore = 0;
    }

    void Update()
    {
        Debug.Log(cupScore);
    }
}
