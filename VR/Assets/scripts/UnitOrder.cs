using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class UnitOrder : MonoBehaviour
{
    public InputActionReference TriggerHold;
    public ActionBasedController rightController;
    public InputActionReference ButtonPressed;
    public LayerMask clickable;
    public LayerMask ground;
    public GameObject circleSelect;
    bool firstClick = true;
    float oldTriggerValue = 0;
    Vector3 defaultScale;
    GameObject circle;
    float scalefactor;
    Vector3 offset;
    private void Start()
    {
        ButtonPressed.action.performed += MoveUnit;
        TriggerHold.action.performed += unitSelectHold;
        offset = new Vector3(0, 0.001f, 0);
    }

    private void OnDestroy()
    {
        TriggerHold.action.performed -= unitSelectHold;
        ButtonPressed.action.performed -= MoveUnit;
    }
    void unitSelectHold(InputAction.CallbackContext context) 
    {
        float triggerValue = context.ReadValue<float>();

        scalefactor = triggerValue + 2;

      
       

        if (Physics.Raycast(rightController.transform.position, rightController.transform.forward, out RaycastHit hit, ground)) 
        {

            if (firstClick == true)
            {
               
                circle = Instantiate(circleSelect, hit.point + offset, Quaternion.identity);
                defaultScale = circle.transform.localScale;
                firstClick = false;
            }
            else if (firstClick == false)
            {
               
                circle.transform.localScale = defaultScale * scalefactor; 
                
            }

            Collider[] enemies = Physics.OverlapSphere(circle.GetComponent<SphereCollider>().gameObject.transform.position,
                circle.GetComponent<SphereCollider>().radius);

        
            selectUnits.Instance.DeSelectAll();

            foreach (Collider col in enemies)
            {
                if(col.gameObject.layer == 7)
                    selectUnits.Instance.Select(col.gameObject);
            }
            

        }
        else
        {
            
        }
   
        if (oldTriggerValue > scalefactor) 
        {
     
            Destroy(circle);
            circle = null;
            firstClick = true;


        }
    
        
        oldTriggerValue = scalefactor;
    }
    public void MoveUnit(InputAction.CallbackContext context)
    {
        Physics.Raycast(rightController.transform.position, rightController.transform.forward, out RaycastHit hit, ground);
        Vector3 newPosition;
        newPosition = hit.point;
        //newPosition += new Vector3(0.0f, 0.05f, 0.0f);
        Debug.Log("new position = " + newPosition);
        for (int i = 1; i < selectUnits.Instance.unitsSelected.Count; i++)
        {
            //transform.Translate(selectUnits.Instance.unitsSelected[i].transform.position = newPosition);
            //selectUnits.Instance.unitsSelected[i].transform.position = transform.Translate(newPosition);
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(newPosition, out navHit, 1.0f, NavMesh.AllAreas))
            {
                newPosition = navHit.position;
            }
            selectUnits.Instance.unitsSelected[i].GetComponent<NavMeshAgent>().SetDestination(newPosition);
        }



    }

}
