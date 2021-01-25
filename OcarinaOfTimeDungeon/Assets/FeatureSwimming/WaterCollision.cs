using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    [SerializeField] private LinkMove myLinkMove;

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit);
        if (hit.gameObject.CompareTag("Water"))
        {
            myLinkMove._speed = 3;
            myLinkMove._groundedPlayer = false;
        }
        else
        {
            myLinkMove._speed = 6;
        }
    }
}
