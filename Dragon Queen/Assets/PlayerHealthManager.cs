using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    CharacterStats stats;
    PlayerStateMachine playerStateMachine;
    public PlayerHealthUI playerHealthUI;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
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
        print("player took damage");
        stats.curHP -= dmg;
        if ( stats.curHP < 1)
        {
            // Dead
          
        }

        UpdatePlayerHealth();
    }
}
