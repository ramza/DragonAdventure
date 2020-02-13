using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletPickup : MonoBehaviour
{

    public AmuletUI.AmuletColors amuletColor;

    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            switch (amuletColor)
            {
                case AmuletUI.AmuletColors.RED:
                    GameManager.Instance.playerData.hasFireAmulet = true;
                    break;
                case AmuletUI.AmuletColors.GREEN:
                    GameManager.Instance.playerData.hasMoonAmulet = true;
                    break;
                case AmuletUI.AmuletColors.YELLOW:
                    GameManager.Instance.playerData.hasSpiritAmulet = true;
                    break;
            }
  
            Destroy(gameObject);
        }
    }
}
