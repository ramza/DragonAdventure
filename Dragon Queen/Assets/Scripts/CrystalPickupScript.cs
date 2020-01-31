using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickupScript : MonoBehaviour
{
    public PlayerMoneyUI moneyUI;

    private void Start()
    {
        moneyUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>().moneyUI;
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moneyUI.AddMoney(1);
            Destroy(gameObject);
        }
    }
}
