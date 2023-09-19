using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    TestInputActions testInputActions;

    float Speed = 0.01f;
    float StickX;
    float StickZ;
    float MoveX;
    float MoveZ;
    void Start()
    {
        testInputActions = new TestInputActions();
        testInputActions.Enable();
        testInputActions.Player.Fire.performed += context => Debug.Log("Fire");
    }

    void Update()
    {

        var direction = testInputActions.Player.Move.ReadValue<Vector2>();
        StickX= direction.x;
        StickZ = direction.y;
        MoveX += StickX * Speed;
        MoveZ += StickZ * Speed;
        this.transform.Translate(MoveX,0,MoveZ);
    }
}