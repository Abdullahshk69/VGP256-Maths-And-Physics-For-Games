using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, ICollision
{
    [SerializeField] float moveSpeed;

    [SerializeField] GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (waypoints[currentWaypointIndex].transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        
        // If Distance between current waypoint and object is less than .1f
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // Moves towards the waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * moveSpeed);

        
    }

    void ICollision.OnCustomCollisionEnter(Shape shape)
    {
        if(shape.gameObject.tag == "Player")
        {
            shape.GetComponent<Respawn>().RespawnPoint();
        }
    }
}
