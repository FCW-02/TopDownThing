using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.F;
    public GameObject flashlightObject;
    public GameObject lampObject;

    void Start()
    {
        flashlightObject.SetActive(false);
        lampObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            flashlightObject.SetActive(!flashlightObject.activeSelf);
            lampObject.SetActive(!lampObject.activeSelf);
        }
    }
}
