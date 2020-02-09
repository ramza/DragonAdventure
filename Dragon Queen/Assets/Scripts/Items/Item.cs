using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        USABLE,
        WEAPON,
        POTION,
        ARMOR,
        RING,
        SHIELD,
        AMULET,
        HELMET,
        QUEST,
    }

    public enum SubItemType
    {
        HEALING,
        MANA,
        SWORD,
        LEATHER,
        IRON,
        GOLD,
        BOW,
        AXE,
        NONE,
    }

    public int id;
    public string name;
    public string iconFileName;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    public ItemType itemType;
    public SubItemType subItemType;

    // Start is called before the first frame update
    public Item(int id, string name, string iconFileName, string description,
                Dictionary<string, int> stats, ItemType type, SubItemType subType)
    {
        this.id = id;
        this.name = name;
        this.iconFileName = iconFileName;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + iconFileName);
        this.stats = stats;
        this.itemType = type;
        this.subItemType = subType;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.iconFileName = item.iconFileName;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.iconFileName);
        this.stats = item.stats;
        this.itemType = item.itemType;
        this.subItemType = item.subItemType;
    }
}
