using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterSwitch : MonoBehaviour
{
    [SerializeField] private float _moveToLocationY;
    private Vector3 waterlow;
    [SerializeField] private float speed;

    void Start()
    {
        waterlow = new Vector3(transform.position.x, _moveToLocationY, transform.position.z);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = Vector3.MoveTowards(transform.position, waterlow, Time.deltaTime * speed);
        }
    }
}
