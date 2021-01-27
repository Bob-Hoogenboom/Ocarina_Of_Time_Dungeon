using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterSwitch : MonoBehaviour
{
    [SerializeField] private float _moveToLocationY = 1;
    private Vector3 waterlow;
    [SerializeField] private float speed = 1;

    void Start()
    {
        waterlow = new Vector3(transform.position.x, _moveToLocationY, transform.position.z);
    }

    public void MoveWaterDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, waterlow, Time.deltaTime * speed);
    }
}
