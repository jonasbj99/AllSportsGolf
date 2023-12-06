using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigController : MonoBehaviour
{
    [SerializeField] GameObject bow;
    [SerializeField] GameObject golf;
    [SerializeField] GameObject tennis;
    [SerializeField] GameObject ball;

    [SerializeField] Transform toolSpawn;
    [SerializeField] Transform ballSpawn;

    public static bool bowSelected;
    public static bool golfSelected;
    public static bool tennisSelected;
    public static bool ballSelected;

    private void Awake()
    {
        bowSelected = false;
        golfSelected = false;
        tennisSelected = false;
        ballSelected = false;
    }

    void Update()
    {
        if(bowSelected)
        {
            ActivateTool(bow);
        }
        else if(golfSelected)
        {
            ActivateTool(golf);
        }
        else if(tennisSelected)
        {
            ActivateTool(tennis);
        }
        else if(ballSelected)
        {
            ActivateTool(ball);
        }

    }

    void ActivateTool(GameObject tool)
    {
        DeactivateTools();

        tool.SetActive(true);
    }

    void DeactivateTools()
    {
        bow.SetActive(false);
        golf.SetActive(false);
        tennis.SetActive(false);
        ball.SetActive(false); 
    }
}
