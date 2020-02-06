using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    CharacterStats stats;
    PlayerStateMachine playerStateMachine;
    public PlayerHealthUI playerHealthUI;
    EquipmentManager equipmentManager;

    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = GetComponentInChildren<EquipmentManager>();
        stats = GetComponent<CharacterStats>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
        UpdatePlayerHealth();
    }

    public void Revive()
    {
        stats.curHP = stats.maxHP;
        UpdatePlayerHealth();

    }

    public void HealPlayer(float amount)
    {
        stats.curHP += amount;
        if(stats.curHP > stats.maxHP)
        {
            stats.curHP = stats.maxHP;
        }

        UpdatePlayerHealth();
    }

    void UpdatePlayerHealth()
    {

        playerHealthUI.UpdatePlayerHealth(stats.curHP, stats.maxHP);
    }

    public void TakeDamage(float dmg)
    {
        // print("player took damage");

        float r = Random.Range(0, dmg+2);
        
        if(r >= equipmentManager.CalculateArmorClass())
        {
            stats.curHP -= dmg;
        }

        if ( stats.curHP < 1)
        {
            playerStateMachine.KillPlayer();
            playerHealthUI.PlayerDeath();
          
        }

        UpdatePlayerHealth();
    }
}
