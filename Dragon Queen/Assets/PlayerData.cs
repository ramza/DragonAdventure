using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public bool hasCap;
    public bool hasArmor;
    public bool hasArms;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void OnDestroy()
    {
        SavePlayerEquipment();
    }

    public void SavePlayerEquipment()
    {
        EquipmentManager equipmentManager;
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            equipmentManager= GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<EquipmentManager>();
        }
        else
        {
            return;
        }
  
        hasCap = equipmentManager.hasCap;
        hasArmor = equipmentManager.hasVest;
    }

    public void CopyEquipmentData(bool cap, bool armor, bool arms)
    {
        this.hasArmor = armor;
        this.hasCap = cap;
        this.hasArms = arms;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
