using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Awake()
    {
        BuildDataBase();
    }

    void BuildDataBase()
    {
        items = new List<Item>()
        {
            //Health Potion
            new Item(0, "Potion", "potion_basic", "A basic healing potion.", 
            new Dictionary<string, int>
            {
                {"Health", 50},
                {"Value", 50 },
            },
            Item.ItemType.USABLE,
            Item.SubItemType.HEALING),
           
        };
    }

    public Item GetItem(int id)
    {
        return items.Find(Item => Item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.name == itemName);
    }
}
