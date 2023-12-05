using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField] Transform stringPullGrab, stringPullVisual, stringPullPoint;
    [SerializeField] BowString bowStringRenderer;
    [SerializeField] float stringLimit = 0.45f;

    float stringStrength;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleased;

    XRGrabInteractable interactable;
    Transform interactor;

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
        OnBowPulled?.Invoke();
    }

    private void RestingString(SelectExitEventArgs arg0)
    {
        OnBowReleased?.Invoke(stringStrength);
        stringStrength = 0;

        interactor = null;
        stringPullGrab.localPosition = Vector3.zero;
        stringPullVisual.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);
    }

    private void FixStringPush(Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z >= 0)
        {
            stringStrength = 0;
            stringPullVisual.localPosition = Vector3.zero;
        }
    }

    private void FixStringToLimit(float pullPointLocalAbsZ, Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z < 0 && pullPointLocalAbsZ >= stringLimit)
        {
            stringStrength = 1;
            stringPullVisual.localPosition = new Vector3(0, 0, -stringLimit);
        }
    }

    private void FixStringPull(float pullPointLocalAbsZ, Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z < 0 && pullPointLocalAbsZ < stringLimit)
        {
            stringStrength = Remap(pullPointLocalAbsZ, 0, stringLimit, 0, 1);
            stringPullVisual.localPosition = new Vector3(0, 0, pullPointLocalSpace.z);
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + (toMin);
    }
}
