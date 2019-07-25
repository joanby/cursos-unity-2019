using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public enum ItemType { WEAPON = 0, ITEM = 1, ARMOR = 2, 
        RING = 3, SPECIAL_ITEMS = 4 };

    public int itemIdx;
    public ItemType type;


    public void ActivateButton(){
        switch (type)
        {
            case ItemType.WEAPON:
                FindObjectOfType<WeaponManager>().ChangeWeapon(itemIdx);
                break;
            case ItemType.ITEM:
                Debug.Log("Consumir item (pendiente)");
                break;
            case ItemType.ARMOR:
                Debug.Log("Cambiar armadura (pendiete)");
                break;
            case ItemType.RING:
                Debug.Log("Equipar anillo (pendiente)");
                break;
        }
        ShowDescription();
    }


    public void  ShowDescription(){
        string desc = "";
        switch (type)
        {
            case ItemType.WEAPON:
                desc =  FindObjectOfType<WeaponManager>().GetWeaponAt(itemIdx).weaponName;
                break;
            case ItemType.ITEM:
                desc = "Item consumible";
                break;
            case ItemType.ARMOR:
                desc = FindObjectOfType<WeaponManager>().GetArmorAt(itemIdx).name;
                break;
            case ItemType.RING:
                desc = FindObjectOfType<WeaponManager>().GetRingAt(itemIdx).name;
                break;
            case ItemType.SPECIAL_ITEMS:
                QuestItem item = FindObjectOfType<ItemsManager>().GetItemAt(itemIdx);
                desc = item.itemName;
                break;
        }
        FindObjectOfType<UIManager>().inventoryText.text = desc;
    }

    public void ClearDescription(){
        FindObjectOfType<UIManager>().inventoryText.text = "";
    }
}
