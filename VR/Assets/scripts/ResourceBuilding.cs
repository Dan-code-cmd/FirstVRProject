using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceBuilding : MonoBehaviour
{
    public BuildingGeneral buildingGeneral;
    public ResourceSetup resourceSetup;
    public float genTime;

    private void Start()
    {
        if (gameObject.name.Contains("Contra"))
        {
            StartCoroutine(ContraGen());
        }
        if (gameObject.name.Contains("Arcana"))
        {
            StartCoroutine(ArcanaGen());
        }
    }
    IEnumerator ContraGen()
    {
        yield return new WaitForSeconds(genTime);
        ResourceSetup.totalContra += 10;
        StartCoroutine(ContraGen());
        
    }
    IEnumerator ArcanaGen()
    {
        yield return new WaitForSeconds(genTime);
        ResourceSetup.totalArcana += 10;
        StartCoroutine(ArcanaGen());
    }

}
