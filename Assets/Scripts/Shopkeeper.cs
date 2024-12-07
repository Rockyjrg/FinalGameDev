using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    [SerializeField] private AudioClip shopSound;
    private bool isPlayerNearby = false;

    // Update is called once per frame
    void Update()
    {
        //check if player is nearby and player is clicking the respective key
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleShopUI();
            SoundManager.Instance.PlaySound(shopSound);
        }
    }

    private void ToggleShopUI()
    {
        //activate or deactivity the shopUI
        shopUI.SetActive(!shopUI.activeSelf);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            shopUI.SetActive(false); //close shop when player leaves
        }
    }
}
