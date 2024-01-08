using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;

public class RigController : MonoBehaviour
{
    XRIDefaultInputActions xriControls;

    [SerializeField] GameObject wristMenu;
    [SerializeField] XRRayInteractor rayInteractor;

    [SerializeField] GameObject leftHandMesh;

    [SerializeField] GameObject golf;
    [SerializeField] GameObject tennis;
    [SerializeField] GameObject bow;

    [SerializeField] Transform toolTransform;
    [SerializeField] Transform ballSpawn;

    [SerializeField] GameObject[] ballPrefabs;

    [SerializeField] Transform startTransform;
    public static Transform currentTransform;
    public static Transform playerTransform;

    BallBehavior ballScript;

    [SerializeField] TextMeshProUGUI scoreCounter;
    int shotCount;

    int golfInt = 0;
    int tennisInt = 1;
    int ballInt = 2;

    float golfOffset = 0.1f;
    float tennisOffset = 1.2f;
    float ballOffset = 0.8f;

    [SerializeField] GameObject tee;
    float teeOffset = 0.1f;

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
        shotCount = 1;
        playerTransform = startTransform;
    }

    void Update()
    {
        currentTransform = ballSpawn;

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

        scoreCounter.text  = "Shots used: " + shotCount;
    }

    public void ActivateGolf()
    {
        DeactivateTools();
        golf.SetActive(true);
        golf.transform.position = toolTransform.position;
        golf.transform.rotation = this.transform.rotation;
        NewBall(golfInt, golfOffset);
    }

    public void ActivateTennis()
    {
        DeactivateTools();
        tennis.SetActive(true);
        tennis.transform.position = toolTransform.position;
        tennis.transform.rotation = this.transform.rotation;
        NewBall(tennisInt, tennisOffset);
    }

    public void ActivateBow()
    {
        DeactivateTools();
        leftHandMesh.SetActive(false);
        bow.SetActive(true);
    }

    public void ActivateBall()
    {
        DeactivateTools();
        NewBall(ballInt, ballOffset);
    }

    public void NextButton()
    {
        DeactivateTools();
        GameObject ball = FindObjectOfType<BallBehavior>().gameObject;
        ballScript = ball.GetComponent<BallBehavior>();
        ballScript.BallDestroy();
        
        shotCount += 1;
        this.transform.position = new Vector3(playerTransform.position.x, this.transform.position.y, playerTransform.position.z);
    }

    public void ResetButton()
    {
        DeactivateTools();
        GameObject ball = FindObjectOfType<BallBehavior>().gameObject;
        Destroy(ball);
        shotCount += 1;
    }

    public void DeactivateTools()
    {
        leftHandMesh.SetActive(true);

        tee.SetActive(false);
        bow.SetActive(false);
        golf.SetActive(false);
        tennis.SetActive(false);
    }

    public void NewBall(int ballType, float offset)
    {
        Vector3 vOffset = new Vector3(0, offset, 0);
        if (ballType != 0) 
        {
            MoveTee(ballType, offset);
        }
        Instantiate(ballPrefabs[ballType], ballSpawn.position + vOffset, Quaternion.identity);

    }

    public void MoveTee(int ballType, float offset)
    {
        tee.SetActive(true);
        Vector3 tOffset = new Vector3(0, offset/2 - teeOffset, 0);
        tee.transform.position = ballSpawn.position + tOffset;
        tee.transform.rotation = gameObject.transform.rotation;
    }
}
