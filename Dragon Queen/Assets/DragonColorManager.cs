using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonColorManager : MonoBehaviour
{

    public Material redMat;
    public Material blueMat;
    public Material greenMat;
    public Material yellowMat;

    public SkinnedMeshRenderer rend;


    private void Start()
    {
        if (GameManager.Instance.playerData.wearingFireAmulet)
        {
            SetRedMaterial();
        }
        else if (GameManager.Instance.playerData.wearingMoonAmulet)
        {
            SetGreenMaterial();
        }
        else if (GameManager.Instance.playerData.wearingSpiritAmulet)
        {
            SetYellowMaterial();
        }
    }

    public void SetRedMaterial()
    {
        rend.material = redMat;
    }
    public void SetBlueMaterial()
    {
        rend.material = blueMat;
    }
    public void SetGreenMaterial()
    {
        rend.material = greenMat;
    }
    public void SetYellowMaterial()
    {
        rend.material = yellowMat;
    }
}
