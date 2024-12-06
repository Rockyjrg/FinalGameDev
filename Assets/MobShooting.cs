using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobShooting : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 2f;

    [Header("Shooting")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireInterval = 2f;
    [SerializeField] private float projectileSpeed = 5f;

    private Vector3 targetPoint;
    private bool movingToPointA = true;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = pointA.position;
        StartCoroutine(ShootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenPoints();
    }

    private void MoveBetweenPoints()
    {
        //move towards the current target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        //switch target point if close enough
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            if (movingToPointA)
            {
                targetPoint = pointB.position;
                movingToPointA = false;
            }
            else
            {
                targetPoint = pointA.position;
                movingToPointA = true;
            }

            //flip the direction of mob
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);
            Shoot();
        }
    }

    private void Shoot()
    {
        //spawn projectile at firing point gameobject
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        //set projectiles velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        float direction = transform.localScale.x > 0 ? 1 : -1; //determine direction based on scale
        rb.velocity = new Vector2(direction * projectileSpeed, 0);

        //rotate projectile to face whichever direction facing
        float angle = direction > 0 ? 0 : 180; //rotate 180 degrees if moving left
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
