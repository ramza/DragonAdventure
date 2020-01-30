﻿using System.Collections;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
