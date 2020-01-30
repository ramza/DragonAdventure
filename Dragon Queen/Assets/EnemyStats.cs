using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public enum EnemyType
    {
        UNDEAD, BEAST, GOBLIN, DRAGON, VAMPIRE, TROLL,
    }

    public enum ElementalType
    {
        FIRE, COLD, LIGHTNING, POISON, EARTH, WIND, WATER, NONE,
    }

    public string enemyName;
    public EnemyType enemyType;
    public ElementalType elementalType;

    public float curHP = 30f;
    public float maxHP = 30f;
    public float curMP = 10f;
    public float maxMP = 10f;

    public float strength = 10f;
    public float dexterity = 10f;
    public float vitality = 10f;
    public float intelligence = 10f;

    public float baseAttackBonus = 1f;
    public float baseDefense = 10f;
    public float magicResistance = 0f;
    public int exp = 10;

    public void Start()
    {
        maxHP = maxHP + Random.Range(1, 10);
        curHP = maxHP;
    }

    public float GetAttackDamage()
    {
        float dmg = Random.Range(1, 6);

        return (int)(dmg + baseAttackBonus + (strength - 10) / 2);
    }

    public float GetAttackRoll()
    {
        float roll = Random.Range(1, 20);

        return roll + (strength - 10) / 2 + baseAttackBonus;
    }

    public float CalculateArmorClass()
    {
        float armorClass = baseDefense + (dexterity - 10) / 2;
        return armorClass;
    }

}
