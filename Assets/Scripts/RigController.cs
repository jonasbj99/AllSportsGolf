using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RigController : MonoBehaviour
{
    XRIDefaultInputActions xriControls;

    [SerializeField] GameObject wristMenu;
    [SerializeField] XRRayInteractor rayInteractor;

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
        xriControls = new XRIDefaultInputActions();

        bowSelected = false;
        golfSelected = false;
        tennisSelected = false;
        ballSelected = false;
    }

    private void OnEnable()
    {
        xriControls.Enable();
    }
    private void OnDisable()
    {
        xriControls.Disable();
    }

    void Update()
    {
        if (xriControls.XRIButtons.X.ReadValue<float>() > 0)
        {
            wristMenu.SetActive(true);
            rayInteractor.enabled = true;
        }
        else if (xriControls.XRIButtons.X.ReadValue<float>() <= 0)
        {
            wristMenu.SetActive(false);
            rayInteractor.enabled = false;
        }
    }

    void ActivateBow()
    {
        DeactivateTools();

        bow.SetActive(true);
    }
    void ActivateGolf()
    {
        DeactivateTools();

        golf.SetActive(true);
    }
    void ActivateTennis()
    {
        DeactivateTools();

        tennis.SetActive(true);
    }
    void ActivateBall()
    {
        DeactivateTools();

        ball.SetActive(true);
    }

    void DeactivateTools()
    {
        bowSelected = false;
        golfSelected = false;
        tennisSelected = false;
        ballSelected = false;

        bow.SetActive(false);
        golf.SetActive(false);
        tennis.SetActive(false);
        ball.SetActive(false); 
    }
}
