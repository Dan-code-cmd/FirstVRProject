using System.Collections.Generic;
using UnityEngine;

public class selectUnits : MonoBehaviour
{

    public List<GameObject> unitList = new List<GameObject> ();
    public List<GameObject> unitsSelected = new List<GameObject>();
    public List<Unit> unitTypes;

    private static  selectUnits _instance;
    public static selectUnits Instance {get { return _instance;}}

    void Awake()
    {
        if(_instance != null && _instance != this) 
        {
            Destroy(this.gameObject);
        }
        else 
        {
            _instance = this;
        }

    }
    public void Select(GameObject unitToAdd)
    {
        //DeSelectAll();
        unitsSelected.Add(unitToAdd);
    }
    public void DeSelectAll() 
    {
        unitsSelected.Clear();
    }

}
