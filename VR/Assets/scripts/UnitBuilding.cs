using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBuilding : MonoBehaviour
{
    public GameObject unit;
    public bool stopSpawn = true;
    public float spawnTime;
    public float spawnDelay;
    private Vector3 spawnOffset;
    

    private void Start()
    {
        InvokeRepeating("SpawnUnit", spawnTime, spawnDelay);
        spawnOffset = new Vector3(0.15f, 0.05f, 0.0f);
    }
    public void SpawnUnit() 
    {
        Instantiate(unit, transform.position + spawnOffset, transform.rotation);
        if (stopSpawn)
        {
            CancelInvoke("SpawnUnit");
        }
    }
}
