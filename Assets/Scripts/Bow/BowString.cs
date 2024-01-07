using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// YouTube videos by Sunny Valley Studio used for this script:
// https://youtube.com/playlist?list=PLcRSafycjWFf8ayYlaVYRFbVnoIcgVY3N&si=twTPm6S9rJ4rCshr

[RequireComponent(typeof(LineRenderer))]
public class BowString : MonoBehaviour
{
    [SerializeField] Transform endpoint_1, endpoint_2;
    LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreateString(Vector3? midPosition)
    {
        Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
        linePoints[0] = endpoint_1.localPosition;
        if (midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }
        linePoints[^1] = endpoint_2.localPosition;

        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }

    void Start()
    {
        CreateString(null);
    }
}
