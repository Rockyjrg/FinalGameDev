using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private float speed = 2f;

    private float time; //time tracker for ping pong

    // Start is called before the first frame update
    void Start()
    {
        //initialize pointA to current position if not set
        pointA = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //increment time based on speed
        time += Time.deltaTime * speed;

        //mathf.pingpong used to interpolate between pointA and pointB
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(time, 1));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pointA, 0.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pointB, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("StandStillMob"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
