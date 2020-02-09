using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject player;
    public GameObject dragon;

    private void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        foreach(Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint.name == GameManager.Instance.spawnPoint)
            {
                player.SetActive(false);
                player.transform.position = spawnPoint.position;
                player.transform.rotation = spawnPoint.rotation;
                player.SetActive(true);

                if(dragon != null)
                {
                 
                   // dragon.transform.position = spawnPoint.position + Vector3.forward * 10f;
               
                }
                   
                return;
            }
        }
    }
}
