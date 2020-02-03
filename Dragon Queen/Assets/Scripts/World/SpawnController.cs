using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public string spawnPointName = "Main";
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
            if ( spawnPoint.name == spawnPointName)
            {
                player.SetActive(false);
                player.transform.position = spawnPoint.position;
                player.SetActive(true);
                dragon.transform.position = spawnPoint.position + Vector3.forward * 10f;
                return;
            }
        }
    }
}
