using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickupScript : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        print("hit something heart");
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealthManager>().HealPlayer(1);
            Destroy(gameObject);
        }
    }
}
