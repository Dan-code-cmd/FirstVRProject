using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceSetup : MonoBehaviour
{
    public static int totalContra = 50;
    public static int totalArcana = 50;
    public TextMeshProUGUI arcanaDisplay;
    public TextMeshProUGUI contraDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       
        arcanaDisplay.text = "Total Arcana = " + totalArcana;
        contraDisplay.text = "Total Contra = " + totalContra;
    }
}
