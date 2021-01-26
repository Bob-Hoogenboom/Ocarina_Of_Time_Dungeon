using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class LinkMove : MonoBehaviour
{
    [SerializeField] private Vector3 _playerVelocity;
    [SerializeField] public bool _groundedPlayer;
    [SerializeField] public float _speed = 6f;
    [SerializeField] private float _turnTime = 0.1f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityScale = -9.81f;
    [SerializeField] private Animator anime;

    private CharacterController charCon;
    private float _gravityValue = -3.0f;
    private float _smoothTurn;

    void Start()
    {
        charCon = GetComponent < CharacterController>();
        anime = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        //old unity input system
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 && _groundedPlayer )  
        {
            anime.SetBool("isMoving", true);
            anime.SetBool("isSwimming", false);
            anime.SetBool("safetyDance", false);
        }
        else
        {
            anime.SetBool("isMoving", false);
        }
                
        _groundedPlayer = charCon.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            CharGroundCheck();
            anime.SetBool("isJumping", false);
        }

        // Changes the height position of the player..
        if (Input.GetButton("Jump") && _groundedPlayer)
        {
            Jump();
            anime.SetBool("isJumping", true);
            anime.SetBool("isSwimming", false);
            anime.SetBool("isMoving", false);
            anime.SetBool("safetyDance", false);
        }

        _playerVelocity.y += _gravityScale * Time.deltaTime;

        //smooth rotation
        if (direction.magnitude >=0.1f)
        {
            PlayerRotate();
        }

        charCon.Move(_playerVelocity * Time.deltaTime);



        void CharGroundCheck()
        {
            _playerVelocity.y = 0f;
        }

        void Jump()
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * _gravityValue * _gravityScale);
            
        }

        void PlayerRotate()
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _smoothTurn, _turnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            charCon.Move(direction * _speed * Time.deltaTime);
        }

        //safety dance
        if(Input.GetKeyDown(KeyCode.B))
        {
            anime.SetBool("safetyDance", true);
            anime.SetBool("isJumping", false);
            anime.SetBool("isSwimming", false);
            anime.SetBool("isMoving", false);
        }

    }

    //if you can read this, GET THE FUCK OUT OF MY CODE. IDIOT! XD
}