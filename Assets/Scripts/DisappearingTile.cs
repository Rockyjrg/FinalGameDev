using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTile : MonoBehaviour
{
    [SerializeField] private float disappearDelay = 1f;
    [SerializeField] private float reappearDelay = 3f;

    private Collider2D tileCollider;
    private SpriteRenderer tileRenderer;

    // Start is called before the first frame update
    void Start()
    {
        tileCollider = GetComponent<Collider2D>();
        tileRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(HandleDisappearAndReappear());
        }
    }

    private IEnumerator HandleDisappearAndReappear()
    {
        yield return new WaitForSeconds(disappearDelay);

        tileRenderer.enabled = false;
        tileCollider.enabled = false;

        yield return new WaitForSeconds(reappearDelay);

        tileRenderer.enabled = true;
        tileCollider.enabled = true;
    }
}
