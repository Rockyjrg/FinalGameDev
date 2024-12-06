using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    [SerializeField] private Transform leftFootSlot;
    [SerializeField] private Transform rightFootSlot;
    [SerializeField] private Transform weaponSlot;

    public void EquipItem(GameObject itemPrefab, string slotType)
    {
        if (slotType == "Shoe")
        {
            // Equip shoe to both feet
            EquipToSlot(itemPrefab, leftFootSlot);
            EquipToSlot(itemPrefab, rightFootSlot);
        }
        else if (slotType == "Weapon")
        {
            // Equip weapon to weapon slot
            EquipToSlot(itemPrefab, weaponSlot);
        }
    }

    private void EquipToSlot(GameObject itemPrefab, Transform slot)
    {
        // Clear existing item
        foreach (Transform child in slot)
        {
            Destroy(child.gameObject);
        }

        //instantiate and use new item
        GameObject newItem = Instantiate(itemPrefab, slot);
        newItem.transform.localPosition = Vector3.zero; //align with the slot
        newItem.transform.localRotation = Quaternion.identity;

    }

}
