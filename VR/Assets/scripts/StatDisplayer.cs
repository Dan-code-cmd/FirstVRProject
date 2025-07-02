using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplayer : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI rangeText;
    public GameObject MK;
    public GameObject MA;
    List<Unit> unitTypes;

    private void Start()
    {
        unitTypes = selectUnits.Instance.unitTypes;
    }

    private void Update()
    {
        
        DisplayUnit();
        nameText.text = unitTypes[Button.unitNumber - 1].unitName;
        hpText.text = "Max HP = " + unitTypes[Button.unitNumber - 1].maxHealth;
        damageText.text = "Damage per attack = " + unitTypes[Button.unitNumber - 1].damagePerSecond;
        rangeText.text = "Range of attack = " + unitTypes[Button.unitNumber - 1].effectiveRange;

    }
    private void DisplayUnit() 
    {
        if(Button.unitNumber == 1)
        {
            MA.SetActive(true);
            MK.SetActive(false);
        }
        else if (Button.unitNumber == 2)
        {
            MA.SetActive(false);
            MK.SetActive(true);

        }
    }
}
