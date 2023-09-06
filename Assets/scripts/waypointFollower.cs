using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointFollower : MonoBehaviour
{

    [SerializeField] GameObject[] wayPoints;

    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;


    void Update()
    {
            
        if(Vector3.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position) < 1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
