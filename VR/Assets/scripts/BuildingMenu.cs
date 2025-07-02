using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BuildingMenu : MonoBehaviour
{
    public InputActionReference ButtonPressed;
    public GameObject _BuildingUICanvas;
    public ActionBasedController leftController;

 
    void Start()
    {
       
        ButtonPressed.action.performed += ToggleMenu;
        _BuildingUICanvas.SetActive(false);

    }

    private void OnDestroy()
    {
        ButtonPressed.action.performed -= ToggleMenu;
    }

    
    void ToggleMenu(InputAction.CallbackContext context)
    {
        if (_BuildingUICanvas.activeSelf == false) 
        {
            _BuildingUICanvas.SetActive(true);
        }
        else 
        {
            _BuildingUICanvas.SetActive(false);
        }
        
       
       
    }
    
}
