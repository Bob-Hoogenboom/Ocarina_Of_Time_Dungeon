using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMove : MonoBehaviour
{
    [SerializeField] private Vector3 _playerVelocity;
    [SerializeField] private bool _groundedPlayer;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _turnTime = 0.1f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityScale = -9.81f;

    private CharacterController charCon;
    private float _smoothTurn;

    void Start()
    {
        charCon = GetComponent<CharacterController>();
    }


    void Update()
    {
        //old unity input system
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);


        _groundedPlayer = charCon.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityScale);
        }

        _playerVelocity.y += _gravityScale * Time.deltaTime;



        //smooth turning
        if (direction.magnitude >=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _smoothTurn, _turnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            charCon.Move(direction * _speed * Time.deltaTime);
        }

        charCon.Move(_playerVelocity * Time.deltaTime);

    }
}
