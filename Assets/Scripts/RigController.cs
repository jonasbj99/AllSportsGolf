using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RigController : MonoBehaviour
{
    XRIDefaultInputActions xriControls;

    [SerializeField] GameObject wristMenu;
    [SerializeField] XRRayInteractor rayInteractor;

    [SerializeField] GameObject leftHandMesh;
    [SerializeField] GameObject rightHandMesh;

    [SerializeField] GameObject bow;
    [SerializeField] GameObject golf;
    [SerializeField] GameObject tennis;
    [SerializeField] GameObject ball;

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

    public void ActivateBow()
    {
        DeactivateTools();
        leftHandMesh.SetActive(false);
        bow.SetActive(true);
    }
    public void ActivateGolf()
    {
        DeactivateTools();
        rightHandMesh.SetActive(false);
        golf.SetActive(true);
    }
    public void ActivateTennis()
    {
        DeactivateTools();
        rightHandMesh.SetActive(false);
        tennis.SetActive(true);
    }
    public void ActivateBall()
    {
        DeactivateTools();
        ball.SetActive(true);
    }

    public void DeactivateTools()
    {
        leftHandMesh.SetActive(true);
        rightHandMesh.SetActive(true);

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
