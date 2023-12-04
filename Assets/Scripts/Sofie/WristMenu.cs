using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    public bool activewristUI = true;
    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }

//kode til hver knap - laves færdigt når hvert spil er klar

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
    }
    // Update is called once per frame
    public void DisplayWristUI()
    {
        if (activewristUI)
        {
            wristUI.SetActive(false);
            activewristUI = false;
        }
        else if (!activewristUI)
        {
            wristUI.SetActive(true);
            activewristUI = true;
        }
    }
}
