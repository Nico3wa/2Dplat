using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] Transform _root;
    [SerializeField] float _speed;
    [SerializeField] float _MovingThreshold;
    Vector2 _playerMovement;
    [SerializeField] Animator _animator;
     Vector2 _JumpForce;
    [SerializeField] float _JumpSpeed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] bool IsGrounded;

     int _doubleJump = 1;

    private void Reset()
    {
        _speed = 2f;
        Debug.Log(_speed);
        _MovingThreshold = 0.1f;

    }


    void Start()
    {
        // Move
        _moveInput.action.started += StartMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += EndMove;

        _jumpInput.action.started += JumpStart;
        _jumpInput.action.performed += UpdateJump;
        _jumpInput.action.canceled += EndJump;

    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    private void EndJump(InputAction.CallbackContext obj)
    {
        _JumpForce = new Vector2(0,0);
    }

    private void UpdateJump(InputAction.CallbackContext obj)
    {
      if (IsGrounded == false && _doubleJump >= 1) 
            {
            _rb.AddForce(transform.up * _JumpSpeed, ForceMode2D.Impulse);
            _doubleJump--;
        }
    }

    private void JumpStart(InputAction.CallbackContext obj)
    {
        //_JumpForce = obj.ReadValue<Vector2>();  
        if (IsGrounded == true)
        {
            _rb.AddForce(transform.up * _JumpSpeed, ForceMode2D.Impulse);
          }

    }

    void FixedUpdate()
    {
        //Debug.Log($"Update !{ _playerMovement}");

        //mouvement
        Vector2 direction = new Vector2(_playerMovement.x, 0);

        // _root.transform.Translate(direction * Time.fixedDeltaTime * _speed);

        _root.transform.Translate(direction * Time.fixedDeltaTime * _speed, Space.World);
        
        if (IsGrounded == true)
        {
            _doubleJump = 1;
        }
        //jump

        


        // Animator
        // Debug.Log($"Magnitude : {direction.magnitude}");
        if (direction.magnitude> _MovingThreshold && IsGrounded== true)  // si on est ent train de bouger alors 
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {                 //sinon c'est qu'on bouge pas donc false
            _animator.SetBool("isWalking", false);

        }

        //Orientaiton FLipp avec le scale 

        //  if (direction.x > 0)     //right
        //  {
        //    _root.localScale = new Vector3(1, 1, 1);
        //  }
        //  else if (direction.x < 0)   //left
        //  {
        //    _root.localScale = (new Vector3(-1, 1, 1));
        // }


        // orientation Flipp avec la rotation du personnage
        if (direction.x > 0)     //right
        {
            _root.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0)   //left
        {
            _root.rotation = Quaternion.Euler(0, 180, 0);
        } 
   }



  public  void StartMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        //Debug.Log($"Appelé ! {_playerMovement}");
    }

    void UpdateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        //Debug.Log($"Joystic UPDATE ! {_playerMovement}");
    }
    void EndMove(InputAction.CallbackContext obj)
    {
        _playerMovement = new Vector2(0, 0);
        //Debug.Log($"Joystic Annulé !");
    }




}
 