using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    AudioSource sound;
    public static int unitNumber;

    void Start()
    {
        unitNumber = 1;
        sound = GetComponent<AudioSource>();
        isPressed = false;
      
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(!isPressed) 
        {
            button.transform.localPosition -= new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
            Debug.Log("pressed");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser) 
        {
            button.transform.localPosition = new Vector3(0, 0, 0);
            onRelease.Invoke();
            isPressed=false;
            
        }
    }
    public void UnitSwapLeft() 
    {
        if(unitNumber == 1) 
        {
            unitNumber = selectUnits.Instance.unitTypes.Count;
        }
        else 
        {
            unitNumber--;
        }
        Debug.Log(unitNumber);
    }
    public void UnitSwapRight()
    {
        if(unitNumber == selectUnits.Instance.unitTypes.Count)
        {
            unitNumber = 1;
        }
        else
        {
            unitNumber++;
        }
        Debug.Log(unitNumber);
    }
}
