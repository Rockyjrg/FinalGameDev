using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float lifetime = 5f;
    [SerializeField] private LayerMask whatIsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<MainCharacterMainHandler>().TakeDamage(1); //damage the player
            Destroy(gameObject); //destroy the object
        }

        if (!collision.CompareTag("Enemy")) //ignore collisions with the mob itself
        {
            Destroy(gameObject);
        }
    }
}
