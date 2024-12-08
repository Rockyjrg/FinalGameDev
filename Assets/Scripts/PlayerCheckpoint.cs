using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector2 currentCheckpoint;
    [SerializeField] private float deathHeight = -20f;

    void Update()
    {
        CheckFallDeath();
    }
    public void SetCheckpoint(Vector2 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint;

        MainCharacterMainHandler mainHandler = GetComponent<MainCharacterMainHandler>();
        if (mainHandler != null)
        {
            mainHandler.ResetHealth();
        }
    }

    private void CheckFallDeath()
    {
        if (transform.position.y < deathHeight)
        {
            Respawn();
        }
    }
}
