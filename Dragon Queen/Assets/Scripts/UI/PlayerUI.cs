using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
