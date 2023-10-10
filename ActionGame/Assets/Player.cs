using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    TestInputActions testInputActions;

    float _speed = 10000f;
    float _stickX;
    float _stickZ;
    float _moveDir;
    float _moveSpeed;
    float _jumpPower;
    Vector3 _move;
    GameObject _player;
    Rigidbody _rb;
    public void OnJump(InputAction.CallbackContext context)
    {
        // ƒWƒƒƒ“ƒv‚·‚é—Í‚ð—^‚¦‚é
        _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        testInputActions = new TestInputActions();
        testInputActions.Enable();
        testInputActions.Player.Fire.performed += context => Debug.Log("Fire");

    }

    void Update()
    {

        var direction = testInputActions.Player.Move.ReadValue<Vector2>();
        _stickX= direction.x;
        _stickZ = direction.y;
        _move = new Vector3(_speed * _stickX,0, _speed * _stickZ);
        _rb.AddForce(_move);
        
        
        
        
    }
}