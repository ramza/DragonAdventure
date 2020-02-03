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

    // Start is called before the first frame update
    void Start()
    {
        leatherArm.SetActive(false);
        leatherVest.SetActive(false);
        leatherCap.SetActive(false);
    }

    public void ActivateArmor()
    {
        hasVest = true;
        leatherVest.SetActive(hasVest);
    }

    public void CopyEquipment(EquipmentManager newEquipment)
    {
        hasCap = newEquipment.hasCap;
        hasArm = newEquipment.hasArm;
        hasVest = newEquipment.hasVest;

        leatherCap.SetActive(hasCap);
        leatherVest.SetActive(hasVest);
        leatherArm.SetActive(hasArm);
 
    }
    
}
