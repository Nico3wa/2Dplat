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
    }

       void FixedUpdate()
    {
        //Debug.Log($"Update !{ _playerMovement}");

        //mouvement
        Vector2 direction = new Vector2(_playerMovement.x, 0);
       _root.transform.Translate( direction * Time.fixedDeltaTime * _speed);


        // Animator
        if (direction.magnitude> _MovingThreshold)  // si on est ent train de bouger alors 
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {                 //sinon c'est qu'on bouge pas donc false
            _animator.SetBool("isWalking", false);

        }
    }

    void StartMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        //Debug.Log($"Appel� ! {_playerMovement}");
    }

    void UpdateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        //Debug.Log($"Joystic UPDATE ! {_playerMovement}");
    }
    void EndMove(InputAction.CallbackContext obj)
    {
        _playerMovement = new Vector2(0, 0);
        //Debug.Log($"Joystic Annul� !");
    }




}
