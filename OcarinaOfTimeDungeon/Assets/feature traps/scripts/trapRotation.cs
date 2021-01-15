using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRotation : MonoBehaviour
{
    [SerializeField] private float speed = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, -transform.right, Time.deltaTime * speed);
    }
}
