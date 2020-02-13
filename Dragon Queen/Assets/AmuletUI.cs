using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AmuletUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
   
    public enum AmuletColors
    {
        RED, YELLOW, GREEN
    }
    public AmuletColors amuletColor;
    public Image iconAmulet;
    public Image iconAmuletEquipment;


    public DragonColorManager dragonColorManager;

    bool wearingAmulet;

    public void OnEnable()
    {

        switch (amuletColor)
        {
            case AmuletColors.RED:
                if (GameManager.Instance.playerData.hasFireAmulet)
                {
                    iconAmulet.enabled = true;
                }
                else
                {
                    iconAmulet.enabled = false;
                }
                break;
            case AmuletColors.GREEN:
                if (GameManager.Instance.playerData.hasMoonAmulet)
                {
                    iconAmulet.enabled = true;
                }
                else
                {
                    iconAmulet.enabled = false;
                }
                break;
            case AmuletColors.YELLOW:
                if (GameManager.Instance.playerData.hasSpiritAmulet)
                {
                    iconAmulet.enabled = true;
                }
                else
                {
                    iconAmulet.enabled = false;
                }
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        switch (amuletColor)
        {
            case AmuletColors.RED:
                if (!GameManager.Instance.playerData.hasFireAmulet)
                {
                   return;
                }

                GameManager.Instance.playerData.wearingFireAmulet = !GameManager.Instance.playerData.wearingFireAmulet;
                if (GameManager.Instance.playerData.wearingFireAmulet)
                {
                    GameManager.Instance.playerData.wearingSpiritAmulet = false;
                    GameManager.Instance.playerData.wearingMoonAmulet = false;
                    iconAmuletEquipment.sprite = iconAmulet.sprite;
                    iconAmuletEquipment.enabled = true;
                    ChangeDragonColor();
                }
                else
                {
                    iconAmuletEquipment.enabled = false;
                    GameManager.Instance.playerData.wearingSpiritAmulet = false;
                    GameManager.Instance.playerData.wearingMoonAmulet = false;
                    dragonColorManager.SetBlueMaterial();
                }
                break;
            case AmuletColors.GREEN:
                if (!GameManager.Instance.playerData.hasMoonAmulet)
                {
                    return;
                }
                GameManager.Instance.playerData.wearingMoonAmulet = !GameManager.Instance.playerData.wearingMoonAmulet;
                if (GameManager.Instance.playerData.wearingMoonAmulet)
                {
                    GameManager.Instance.playerData.wearingSpiritAmulet = false;
                    GameManager.Instance.playerData.wearingFireAmulet = false;
                    iconAmuletEquipment.sprite = iconAmulet.sprite;
                    iconAmuletEquipment.enabled = true;
                    ChangeDragonColor();
                }
                else
                {
                    GameManager.Instance.playerData.wearingSpiritAmulet = false;
                    GameManager.Instance.playerData.wearingFireAmulet = false;
                    iconAmuletEquipment.enabled = false;
                    dragonColorManager.SetBlueMaterial();
                }
                break;
            case AmuletColors.YELLOW:
                if (!GameManager.Instance.playerData.hasSpiritAmulet)
                {
                    return;
                }
                GameManager.Instance.playerData.wearingSpiritAmulet = !GameManager.Instance.playerData.wearingSpiritAmulet;
                if (GameManager.Instance.playerData.wearingSpiritAmulet)
                {
                    GameManager.Instance.playerData.wearingMoonAmulet = false;
                    GameManager.Instance.playerData.wearingFireAmulet = false;
                    iconAmuletEquipment.sprite = iconAmulet.sprite;
                    iconAmuletEquipment.enabled = true;
                    ChangeDragonColor();
                }
                else
                {
                    GameManager.Instance.playerData.wearingMoonAmulet = false;
                    GameManager.Instance.playerData.wearingFireAmulet = false;
                    iconAmuletEquipment.enabled = false;
                    dragonColorManager.SetBlueMaterial();
                }
                break;
        }

       
    }


    public void ChangeDragonColor()
    {
        if(dragonColorManager == null)
        {
            return;
        }
        switch (amuletColor)
        {
            case AmuletColors.RED:
                dragonColorManager.SetRedMaterial();
                break;
            case AmuletColors.GREEN:
                dragonColorManager.SetGreenMaterial();
                break;
            case AmuletColors.YELLOW:
                dragonColorManager.SetYellowMaterial();
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }
}
