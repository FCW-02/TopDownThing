using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.F;
    public GameObject flashlightObject;
    public GameObject flashlightObject2;
    public GameObject lampObject;

    void Start()
    {
        flashlightObject.SetActive(false);
        flashlightObject2.SetActive(false);
        lampObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            flashlightObject.SetActive(!flashlightObject.activeSelf);
            flashlightObject2.SetActive(!flashlightObject2.activeSelf);
            lampObject.SetActive(!lampObject.activeSelf);
        }
    }
}
