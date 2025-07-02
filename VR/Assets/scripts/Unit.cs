using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Unit : MonoBehaviour
{
    string state;
    public string unitName;
    public float maxHealth;
    public float damagePerSecond;
    public float effectiveRange;
 
    void Start()
    {
       
        selectUnits.Instance.unitList.Add(this.gameObject);
    }
    void OnDestroy()
    {
       
        selectUnits.Instance.unitList.Remove(this.gameObject);
    }


}
