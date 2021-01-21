using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchCollision : MonoBehaviour
{
    public UnityEvent waterDown;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("event dmg function");
            waterDown.Invoke(); //assign the waterdown function
        }
    }
}
