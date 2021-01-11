using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMove : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _turnTime = 0.1f;

    private float _smoothTurn;

    public CharacterController charCon;

   

    void Update()
    {
        //old unity input system
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _smoothTurn, _turnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            charCon.Move(direction * _speed * Time.deltaTime);
        }
    }
}
