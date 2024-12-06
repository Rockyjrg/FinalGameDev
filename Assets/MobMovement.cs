using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{

    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private float speed = 2f;

    private Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        //move foward target
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        //flip target when reaches destination
        if (Vector3.Distance(transform.position, pointA) < 0.1f)
        {
            targetPoint = pointB;
            FlipSprite();
        }
        else if (Vector3.Distance(transform.position, pointB) < 0.1f)
        {
            targetPoint = pointA;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pointA, pointB);
        Gizmos.DrawSphere(pointA, 0.1f);
        Gizmos.DrawSphere(pointB, 0.1f);
    }
}
