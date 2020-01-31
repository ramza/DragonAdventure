using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemDrop : MonoBehaviour
{
    public int[] weightTable = { 60, 30, 20 };
    public GameObject[] dropItems;

    int total = 0;

    // Start is called before the first frame update
    void Start()
    {
   
        foreach(int weight in weightTable)
        {
            total += weight;
        }
    }

    public void DropLoot()
    {

        int r = Random.Range(0, total);

        for (int i = 0; i < weightTable.Length; i++)
        {
            if (r < weightTable[i])
            {
                Debug.Log("dropping item");
    
                Instantiate(dropItems[i], transform.position, Quaternion.identity);
                return;
            }
            else
            {
                r -= weightTable[i];
            }
        }
 
    }
}
