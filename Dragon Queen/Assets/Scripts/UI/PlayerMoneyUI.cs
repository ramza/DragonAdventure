using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyUI : MonoBehaviour
{

    int totalMoneys = 0;
    public Text moneyText;

    public void AddMoney(int amount)
    {
        totalMoneys += amount;
        moneyText.text = totalMoneys.ToString();
        GameManager.Instance.crystals = totalMoneys;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalMoneys = GameManager.Instance.crystals;
        moneyText.text = totalMoneys.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
