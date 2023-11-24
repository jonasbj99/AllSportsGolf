using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnim : MonoBehaviour
{
    public InputActionProperty pinchAnim;
    public InputActionProperty grabAnim;

    public Animator handAnim;

    void Update()
    {
        float pinchValue = pinchAnim.action.ReadValue<float>();
        handAnim.SetFloat("Pinch", pinchValue);
        //Debug.Log("Pinch Value: " + pinchValue);

        float grabValue = grabAnim.action.ReadValue<float>();
        handAnim.SetFloat("Grab", grabValue);
        //Debug.Log("Grab Value: " + grabValue);
    }
}
