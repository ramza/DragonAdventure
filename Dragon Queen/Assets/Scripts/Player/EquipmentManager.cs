using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject basicSword;
    public GameObject masterSword;

    public GameObject leatherCap;
    public GameObject leatherVest;
    public GameObject leatherArm;
    public GameObject basicShield;

    public bool hasCap;
    public bool hasVest;
    public bool hasArm;

    public ItemUI itemUI;

    // Start is called before the first frame update
    void Start()
    {
 

        
    }


    public void ActivateArmor()
    {
        hasVest = true;
        leatherVest.SetActive(hasVest);
        itemUI.SetLeatherArmor(hasVest);

    }


    public void ActivateCap()
    {
        hasCap = true;
        leatherCap.SetActive(hasCap);
        itemUI.SetLeatherCap(hasCap);

    }

    public void CopyEquipment(bool cap, bool vest, bool arm)
    {
        hasCap = cap;
        hasArm = arm;
        hasVest = vest;

        leatherCap.SetActive(hasCap);
        leatherVest.SetActive(hasVest);
        leatherArm.SetActive(hasArm);

    }

    public float CalculateArmorClass()
    {
        float AC = 0;
        if (hasVest)
        {
            AC += 1;
        }
        if (hasCap)
        {
            AC += 1;
        }
        return AC;
    }

    public void CopyEquipment(EquipmentManager newEquipment)
    {
        
        hasCap = newEquipment.hasCap;
        hasArm = newEquipment.hasArm;
        hasVest = newEquipment.hasVest;

        leatherCap.SetActive(hasCap);
        leatherVest.SetActive(hasVest);
        itemUI.SetLeatherArmor(hasVest);
        leatherArm.SetActive(hasArm);
 
    }
    
}
