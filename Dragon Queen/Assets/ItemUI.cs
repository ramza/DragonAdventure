using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemUI : MonoBehaviour
{
    public Image leatherArmor;
    public Image leatherCap;

    bool wearingLeatherArmor;
    bool wearingLeatherCap;

    // Start is called before the first frame update
    void Start()
    {
        //leatherArmor.enabled = false;    
    }

    public void OnEnable()
    {
        print("inventory enabled");
        leatherArmor.enabled = wearingLeatherArmor;
        leatherCap.enabled = wearingLeatherCap;
    }

    public void SetLeatherArmor(bool val)
    {
        wearingLeatherArmor= val;
        leatherArmor.enabled = wearingLeatherArmor;
    }

    public void SetLeatherCap(bool val)
    {
        wearingLeatherCap = val;
        leatherCap.enabled = wearingLeatherCap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
