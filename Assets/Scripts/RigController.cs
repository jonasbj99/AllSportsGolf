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

    [SerializeField] GameObject bow;
    [SerializeField] GameObject golf;
    [SerializeField] GameObject tennis;
    [SerializeField] GameObject throwBall;

    [SerializeField] GameObject[] ballPrefabs;

    [SerializeField] Transform startTransform;
    public static Transform currentTransform;
    public static Transform previousTransform;

    // tool transform

    GameObject ball;
    BallBehavior ballScript;

    int shotCount;

    int golfInt = 0;
    int tennisInt = 1;
    int ballInt = 2;

    private void Awake()
    {
        xriControls = new XRIDefaultInputActions();
    }

    private void OnEnable()
    {
        xriControls.Enable();
    }
    private void OnDisable()
    {
        xriControls.Disable();
    }

    void Start()
    {
        shotCount = 0;
        previousTransform = startTransform;
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
        golf.SetActive(true);
        // Move golf club
        NewBall(golfInt);
    }

    public void ActivateTennis()
    {
        DeactivateTools();
        tennis.SetActive(true);
        // Move tennis bat
        NewBall(tennisInt);
    }

    public void ActivateBall()
    {
        DeactivateTools();
        ball.SetActive(true);
        NewBall(ballInt);
    }

    public void NextButton()
    {
        ball = FindObjectOfType<BallBehavior>().gameObject;
        ballScript = ball.GetComponent<BallBehavior>();
        ballScript.BallDestroy();
        previousTransform = currentTransform;
        shotCount += 1;
        // TP player
    }

    public void ResetButton()
    {
        ball = FindObjectOfType<BallBehavior>().gameObject;
        ballScript = ball.GetComponent<BallBehavior>();
        ballScript.BallReset();
        shotCount += 1;
    }

    public void DeactivateTools()
    {
        leftHandMesh.SetActive(true);

        bow.SetActive(false);
        golf.SetActive(false);
        tennis.SetActive(false);
        ball.SetActive(false); 
    }

    public void NewBall(int ballType)
    {
        Vector3 ballOffset = new Vector3(0f, 0.5f, 0f);
        Instantiate(ballPrefabs[ballType], previousTransform.position + ballOffset, Quaternion.identity);
    }
}
