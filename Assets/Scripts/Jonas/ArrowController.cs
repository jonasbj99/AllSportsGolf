using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] GameObject stringPullVisual, arrowPrefab, arrowSpawnPoint;
    [SerializeField] float arrowMaxSpeed = 10;
    [SerializeField] AudioSource releaseAudioSource;

    public void PrepareArrow()
    {
        stringPullVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        releaseAudioSource.Play();
        stringPullVisual.SetActive(false);

        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = stringPullVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(stringPullVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
        RigController rigScript = FindObjectOfType<RigController>();
        rigScript.DeactivateTools();
    }
}
