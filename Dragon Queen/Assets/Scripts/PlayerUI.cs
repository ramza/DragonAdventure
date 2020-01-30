using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Transform startSpawn;
    GameObject player;
    GameObject dragon;
    public GameObject gameOverButton;
    public PlayerMoneyUI moneyUI;
    // Start is called before the first frame update
    void Start()
    {
        dragon = GameObject.FindGameObjectWithTag("Dragon"); 
        player = GameObject.FindGameObjectWithTag("Player");
        gameOverButton.SetActive(false);
    }

    public void ResetPlayer()
    {
        player.SetActive(false);
        player.transform.position = startSpawn.position;
        dragon.transform.position = startSpawn.position + Vector3.forward * 5f;
        player.SetActive(true);
        player.GetComponent<PlayerHealthManager>().Revive();
        player.GetComponent<PlayerStateMachine>().Revive();
        gameOverButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
