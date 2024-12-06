using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int cost;
    public Sprite icon; // Optional: For displaying in UI
    public int healthBoost;
    public int damageBoost;
    public float speedBoost;
    public int jumpForce;
    public GameObject itemPrefab;
    public string slotType;
}
