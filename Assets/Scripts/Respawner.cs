using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    [SerializeField] private GameObject mobPrefab;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay = 5f;

    public void RespawnMob()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);

        if (mobPrefab != null && respawnPoint != null)
        {
            Instantiate(mobPrefab, respawnPoint.position, Quaternion.identity);
        }
    }
}
