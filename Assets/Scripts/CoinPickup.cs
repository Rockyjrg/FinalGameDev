using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] private int goldAmount = 1;
    [SerializeField] private AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<MainCharacterMainHandler>().AddGold(goldAmount);
            SoundManager.Instance.PlaySound(coinSound);
            Destroy(gameObject);
        }
    }
}
