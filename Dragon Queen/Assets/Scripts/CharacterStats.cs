
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    private Dictionary<int, int> expPerLevel = new Dictionary<int, int>();
    public enum CharacterClass
    {
        RANGER, MAGE, FIGHTER,
    }

    public string characterName;
    public CharacterClass characterClass;
    public int level = 1;
    public float curHP = 50f;
    public float maxHP = 50f;
    public float curMP = 11f;
    public float maxMP = 11f;

    public float strength = 16f;
    public float dexterity = 14f;
    public float vitality = 10f;
    public float intelligence = 10f;

    private float baseAttackTime = 0.7f;
    public float baseAttackBonus = 2f;
    public float attackAnimSpeed = 1f;
    public float baseDefense = 10;
    public float magicResistance = 0f;
    public float exp = 0f;
    public string playerNickName;

    public float CalculateDamage()
    {
        return baseAttackBonus + strength / 2;
    }

}
