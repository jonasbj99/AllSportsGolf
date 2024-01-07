using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

// YouTube videos by Sunny Valley Studio used for this script:
// https://youtube.com/playlist?list=PLcRSafycjWFf8ayYlaVYRFbVnoIcgVY3N&si=twTPm6S9rJ4rCshr

public class BowStringController : MonoBehaviour
{
    [SerializeField] Transform stringPullGrab, stringPullVisual, stringPullPoint;
    [SerializeField] BowString bowStringRenderer;
    [SerializeField] float stringLimit = 0.42f;

    float stringStrength, previousStrength;

    [SerializeField] AudioSource stringAudioSource;
    [SerializeField] float stringSoundThreshold = 0.001f;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleased;

    [SerializeField] SkinnedMeshRenderer handMesh;

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

            previousStrength = stringStrength;

            FixStringPush(pullPointLocalSpace);

            FixStringToLimit(pullPointLocalAbsZ, pullPointLocalSpace);

            FixStringPull(pullPointLocalAbsZ, pullPointLocalSpace);

            bowStringRenderer.CreateString(stringPullVisual.position);

            handMesh.enabled = false;
        }
    }

    void PrepareString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactorObject.transform;
        OnBowPulled?.Invoke();
    }

    void RestingString(SelectExitEventArgs arg0)
    {
        OnBowReleased?.Invoke(stringStrength);
        stringStrength = 0;
        previousStrength = 0;
        stringAudioSource.pitch = 1;
        stringAudioSource.Stop();

        interactor = null;
        stringPullGrab.localPosition = Vector3.zero;
        stringPullVisual.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);

        handMesh.enabled = true;
    }

    void FixStringPush(Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z >= 0)
        {
            stringAudioSource.pitch = 1;
            stringAudioSource.Stop();
            stringStrength = 0;
            stringPullVisual.localPosition = Vector3.zero;
        }
    }

    void FixStringToLimit(float pullPointLocalAbsZ, Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z < 0 && pullPointLocalAbsZ >= stringLimit)
        {
            stringAudioSource.Pause();
            stringStrength = 1;
            stringPullVisual.localPosition = new Vector3(0, 0, -stringLimit);
        }
    }

    void FixStringPull(float pullPointLocalAbsZ, Vector3 pullPointLocalSpace)
    {
        if (pullPointLocalSpace.z < 0 && pullPointLocalAbsZ < stringLimit)
        {
            if(stringAudioSource.isPlaying == false && stringStrength <= 0.01f)
            {
                stringAudioSource.Play();
            }

            stringStrength = Remap(pullPointLocalAbsZ, 0, stringLimit, 0, 1);
            stringPullVisual.localPosition = new Vector3(0, 0, pullPointLocalSpace.z);

            PlayPullSound();
        }
    }

    void PlayPullSound()
    {
        if (Mathf.Abs(stringStrength - previousStrength) > stringSoundThreshold)
        {
            if (stringStrength < previousStrength)
            {
                stringAudioSource.pitch = -1;
            }
            else
            {
                stringAudioSource.pitch = 1;
            }
            stringAudioSource.UnPause();
        }
        else
        {
            stringAudioSource.Pause();
        }
    }

    float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + (toMin);
    }
}
