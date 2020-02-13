using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool completedTutorial = true;
    public bool hasCap;
    public bool hasArmor;
    public bool hasArms;
    public bool hasMushroom;
    public bool hasBook;
    public bool hasMirror;

    public bool hasMoonAmulet;
    public bool hasFireAmulet;
    public bool hasSpiritAmulet;

    public bool wearingMoonAmulet;
    public bool wearingFireAmulet;
    public bool wearingSpiritAmulet;


    public Dictionary<string, bool> questList = new Dictionary<string, bool>();
    private Dictionary<string, bool> chests = new Dictionary<string, bool>();

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

    public void AddChest(string id)
    {
        if (chests.ContainsKey(id))
        {
            return;
        }
        else
        {
            chests.Add(id, false);
        }
    }

    public bool IsChestOpen(string id)
    {
        return chests[id];
    }

    public void OpenChest(string id)
    {
        chests[id] = true;
    }

    public Dictionary<string, bool> GetWorldObjectData()
    {
        return chests;
    }

    public void AddQuest(string id)
    {
        if (questList.ContainsKey(id))
        {
            return;
        }
        else
        {
            questList.Add(id, false);
        }
    }

    public bool IsQuestStarted(string id)
    {
        return questList.ContainsKey(id);
    }

    public bool IsQuestComplete(string id)
    {
        return questList[id];
    }

    public void CompleteQuest(string id)
    {
        questList[id] = true;
    }

    public Dictionary<string, bool> GetQuests()
    {
        return questList;
    }
}
