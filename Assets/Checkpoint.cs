using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCheckpoint player = collision.GetComponent<PlayerCheckpoint>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
            }
        }
    }
}