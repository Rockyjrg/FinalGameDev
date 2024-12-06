using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCollisionHandler : MonoBehaviour
{

    [SerializeField] private float bounceForce = 5f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.GetContact(0);

            if (contact.normal.y < -0.5f)
            {
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

                if (playerRb != null)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
                }

                Respawner respawner = FindObjectOfType<Respawner>();
                if (respawner != null)
                {
                    respawner.RespawnMob();
                }

                Destroy(gameObject);
            }
            else
            {
                //player hit the mob from the side
                collision.gameObject.GetComponent<MainCharacterMainHandler>()?.TakeDamage(1);
            }
        }
    }
}
