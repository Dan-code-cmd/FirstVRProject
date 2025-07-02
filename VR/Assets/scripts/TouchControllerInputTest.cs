using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchControllerInputTest : MonoBehaviour
{
    public InputActionReference triggerAmount;

    public ActionBasedController leftcontroller;
    void Start()
    {
        triggerAmount.action.performed += TriggerPressedDown;
        triggerAmount.action.canceled += TriggerPressedDown;
    }

    void TriggerPressedDown(InputAction.CallbackContext context) 
    {
        float triggerValue = context.ReadValue<float>();

        Debug.Log("Left trigger value:" + triggerValue);

        if (triggerValue > 0.5f) 
            leftcontroller.SendHapticImpulse(0.5f, 0.1f);
    }
}
