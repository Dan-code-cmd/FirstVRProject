using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SpellsGeneral : MonoBehaviour
{
    public InputActionReference ButtonPressed;
    public GameObject[] spells;
    public ActionBasedController leftController;
    GameObject selectedSpell;

    private void OnDestroy()
    {

    }
    public void SelectSpell(GameObject SelectedSpell)
    {
        if (ResourceSetup.totalArcana < 20)
        {
           
        }
        else
        {
            ResourceSetup.totalArcana -= 20;
            selectedSpell = SelectedSpell;
            ButtonPressed.action.performed += CastSpell;
        }

    }
    public void CastSpell(InputAction.CallbackContext context)
    {
        Physics.Raycast(leftController.transform.position, leftController.transform.forward, out RaycastHit hit);
        Instantiate(selectedSpell, hit.point, Quaternion.identity);
        ButtonPressed.action.performed -= CastSpell;
    }
}
