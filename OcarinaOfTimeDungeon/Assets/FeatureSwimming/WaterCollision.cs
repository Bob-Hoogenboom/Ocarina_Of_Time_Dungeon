using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    [SerializeField] private LinkMove myLinkMove;

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Water"))
        {
            myLinkMove._speed = 3;
            myLinkMove._groundedPlayer = false;

            myLinkMove.anime.SetBool("isSwimming", true);
            myLinkMove.anime.SetBool("isMoving", false);
            myLinkMove.anime.SetBool("isJumping", false);
        }
        else
        {
            myLinkMove._speed = 6;
        }
    }
}
