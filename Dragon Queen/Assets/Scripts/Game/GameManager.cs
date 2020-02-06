using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    // id, amount
    //private Dictionary<int, int> inventoryItemsByID = new Dictionary<int, int>();
    private Dictionary<string, bool> chests = new Dictionary<string, bool>();

    public int crystals;

    public string spawnPoint = "Main";
    public PlayerData playerData;

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

    public void AddChest(string id)
    {
        if (chests.ContainsKey(id))
        {
            return;
        }
        else
        {
            chests.Add(id, false);
        }
    }

    public bool IsChestOpen(string id)
    {
        return chests[id];
    }

    public void OpenChest(string id)
    {
        chests[id] = true;
    }

    public Dictionary<string, bool> GetWorldObjectData()
    {
        return chests;
    }

}
