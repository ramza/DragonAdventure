﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elizadore : MonoBehaviour
{
    public GameObject mushroomWizard;
    public GameObject bookWizard;



    // Start is called before the first frame update
    void Start()
    {
        mushroomWizard.SetActive(false);
        bookWizard.SetActive(false);


        if (GameManager.Instance.playerData.hasMushroom)
        {
            bookWizard.SetActive(true);
        }
        else
        {
            mushroomWizard.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}