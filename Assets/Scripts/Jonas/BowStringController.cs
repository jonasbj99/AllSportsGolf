using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField] BowString bowStringRenderer;
    [SerializeField] Transform stringPullGrab, stringPullVisual, stringPullPoint;

    XRGrabInteractable interactable;
    Transform interactor;

    float stringLimit = 0.45f;

    void Awake()
    {
        interactable = stringPullGrab.GetComponent<XRGrabInteractable>();
    }

    void Start()
    {
        interactable.selectEntered.AddListener(PrepareString);
        interactable.selectExited.AddListener(RestingString);
    }

    void Update()
    {
        if (interactor != null)
        {
            // Convert bow string pull point position to local space of the pull point
            Vector3 pullPointLocalSpace = stringPullPoint.InverseTransformPoint(stringPullGrab.position);

            // Get the offset
            float pullPointLocalAbsZ = Mathf.Abs(pullPointLocalSpace.z);

            FixStringPush(pullPointLocalSpace);

            FixStringToLimit(pullPointLocalAbsZ, pullPointLocalSpace);

            FixStringPull(pullPointLocalAbsZ, pullPointLocalSpace);

            bowStringRenderer.CreateString(stringPullVisual.position);
        }
    }

    private void PrepareString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactorObject.transform;
    }

    private void RestingString(SelectExitEventArgs arg0)
    {
        interactor = null;
        stringPullGrab.localPosition = Vector3.zero;
        stringPullVisual.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);
    }

    private void FixStringPush(Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z >= 0)
        {
            stringPullVisual.localPosition = Vector3.zero;
        }
    }

    private void FixStringToLimit(float pullPointLocalAbsZ, Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z < 0 && pullPointLocalAbsZ >= stringLimit)
        {
            stringPullVisual.localPosition = new Vector3(0, 0, -stringLimit);
        }
    }

    private void FixStringPull(float pullPointLocalAbsZ, Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z < 0 && pullPointLocalAbsZ < stringLimit)
        {
            stringPullVisual.localPosition = new Vector3(0, 0, pullPointLocalSpace.z);
        }
    }
}
