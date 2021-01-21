using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterSwitch : MonoBehaviour
{
    [SerializeField] private float _moveToLocationY;
    private Vector3 waterlow;
    [SerializeField] private float speed;
    //[SerializeField] private GameObject waterSwitch;

    bool isPushed = false;

    void Start()
    {
        waterlow = new Vector3(transform.position.x, _moveToLocationY, transform.position.z);
    }

    //void Update()
    //{
    //    OnTriggerEnter(waterSwitch.GetComponent<MeshCollider>());
    //}

    public void MoveWaterDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, waterlow, Time.deltaTime * speed);
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    Debug.Log(col);
    //    //if (!isPushed)
    //    //{
    //    //    isPushed = true;
            
    //    //}
    //    gameObject.transform.position = Vector3.MoveTowards(transform.position, waterlow, Time.deltaTime * speed);
    //}
}
