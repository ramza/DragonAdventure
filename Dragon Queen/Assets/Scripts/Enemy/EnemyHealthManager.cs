using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealthManager : MonoBehaviour
{
    private float timer;
    private float immunityTime = 0.1f;
    private EnemyStateMachine enemyStateMachine;
    private CharacterController cc;
    private EnemyStats enemyStats;
    private ItemDrop itemDrop;
    private bool dead;
    public float dropRate = 50f;

    private void Start()
    {
        itemDrop = GetComponent<ItemDrop>();
        cc = GetComponent<CharacterController>();
        enemyStateMachine = GetComponent<EnemyStateMachine>();
        enemyStats = GetComponent<EnemyStats>();
    }

    private void OnEnable()
    {
        if (IsDead())
        {
            enemyStateMachine.Kill();
        }
    }

    public void Heal(float amount)
    {
        enemyStats.curHP += amount;
        if (enemyStats.curHP > enemyStats.maxHP)
        {
            enemyStats.curHP = enemyStats.maxHP;
        }
    }

    public bool CanHit(float attack)
    {
        if (attack < enemyStats.baseDefense)
            print("player missed the goblin");
        return attack >= enemyStats.baseDefense;
    }

    public void Hurt(float amount)
    {
        if (dead)
        {
            return;
        }
        TakeDamage(amount);
    }

    void TakeDamage(float amount)
    {

        enemyStats.curHP -= amount;
        print("hit the goblin");
        if (enemyStats.curHP <= 0)
        {
            dead = true;
            cc.enabled = false;
            EnemyKill();
        }
    }

    public bool IsDead()
    {
        return dead;
    }

    void EnemyKill()
    {
        enemyStateMachine.Kill();
        float r = Random.Range(1, 100);
        if (r < dropRate)
        {
            itemDrop.DropLoot();
        }

    }
}
