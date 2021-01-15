using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapCollision : MonoBehaviour
{
    public UnityEvent takeKB;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("event dmg function");
            takeKB.Invoke(); //assign the knockback function
        }
    } 
}
