using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BuildingGeneral : MonoBehaviour
{   
    public InputActionReference ButtonPressed;
    public GameObject[] Buildables;
    public ActionBasedController rightController;
    static GameObject selectedBuilding;
    private void Start()
    {
       
    }

    private void OnDestroy()
    {
      
    }
    public void BuildingSelect(GameObject SelectedBuilding)
    {
        if(ResourceSetup.totalContra < 10)
        {
          
        }
        else
        {
            ResourceSetup.totalContra -= 10;
            selectedBuilding = SelectedBuilding;
            ButtonPressed.action.performed += PlaceBuilding;
        }
     
    }
    public void PlaceBuilding(InputAction.CallbackContext context) 
    {
        Physics.Raycast(rightController.transform.position, rightController.transform.forward, out RaycastHit hit);
        Instantiate(selectedBuilding, hit.point, Quaternion.identity);
        ButtonPressed.action.performed -= PlaceBuilding;
    }

}
