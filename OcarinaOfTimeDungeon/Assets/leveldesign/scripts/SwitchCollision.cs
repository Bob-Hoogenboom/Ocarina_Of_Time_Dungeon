using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchCollision : MonoBehaviour
{
    public UnityEvent waterDown;
    public CharacterController character;

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("UnderWaterSwitch"))
        {
            for (int i = 0; i < 3; i++)
            {
                waterDown.Invoke();
            }
        }
    }
}