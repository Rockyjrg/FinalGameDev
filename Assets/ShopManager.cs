using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    public class ShopSlot
    {
        public Item item;
        public TextMeshProUGUI costText;
        public KeyCode purchaseKey;
    }

    [SerializeField] private List<ShopSlot> shopSlots;
    private MainCharacterMainHandler player;
    private EquipmentManager equipmentManager;

    private void Start()
    {
        player = FindObjectOfType<MainCharacterMainHandler>();

        foreach (ShopSlot slot in shopSlots)
        {
            if (slot.item != null)
            {
                slot.costText.text = $"Cost: {slot.item.cost}G";
            }
        }

        equipmentManager = FindObjectOfType<EquipmentManager>();
    }

    private void Update()
    {
        foreach (ShopSlot slot in shopSlots)
        {
            if (Input.GetKeyDown(slot.purchaseKey) && player != null)
            {
                AttemptPurchase(slot.item);
            }
        }
    }

    private void AttemptPurchase(Item item)
    {
        if (player.GetGold() >= item.cost)
        {
            player.SpendGold(item.cost);
            ApplyItemEffects(item);
            Debug.Log($"{item.itemName} purchased!");
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }

    private void ApplyItemEffects(Item item)
    {
        if (item.healthBoost != 0) player.AddHealth(item.healthBoost);
        //        if (item.damageBoost != 0) player.AddDamage(item.damageBoost);
        if (item.speedBoost != 0) player.AddSpeed(item.speedBoost);
        if (item.jumpForce != 0) player.AddJump(item.jumpForce);

        //equip visual of items
        if (item.itemPrefab != null && equipmentManager != null)
        {
            equipmentManager.EquipItem(item.itemPrefab, item.slotType);
        }
    }
}
