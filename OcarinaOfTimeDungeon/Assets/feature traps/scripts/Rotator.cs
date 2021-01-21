using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speed = 90.0f;

    void Update()
    {
        transform.RotateAround(transform.position, -transform.right, Time.deltaTime * speed);
    }
}
