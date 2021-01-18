using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] _waypoints;
    int current = 0;
    public float speed;
    float WPradius = 1;

    void Update()
    {
        if (Vector3.Distance(_waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= _waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[current].transform.position, Time.deltaTime * speed);

    }
}