using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    public int crystals;

    public string spawnPoint = "Main";
    public PlayerData playerData;

    [Range(0, 1)]
    public float currentTimeOfDay = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }

   

}
