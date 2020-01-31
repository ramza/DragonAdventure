using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public float hp = 1;
    ItemDrop itemDrop;
    // Start is called before the first frame update
    void Start()
    {
        itemDrop = GetComponent<ItemDrop>();
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if ( hp <= 0)
        {
            itemDrop.DropLoot();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
