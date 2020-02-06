using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDoor : MonoBehaviour
{
    public EnemyHealthManager[] monsters;

    float timer;
    float tick = 1f;
    public GameObject door;

    bool open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            return;
        }
        timer += Time.deltaTime;
        if ( timer > tick)
        {
            timer = 0;
            int deadMonsters = 0;
            foreach(EnemyHealthManager monster in monsters)
            {
                if (monster.IsDead())
                {
                    deadMonsters += 1;
                }
            }
            if(deadMonsters == monsters.Length)
            {
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        open = true;
        door.SetActive(false);
    }
}
