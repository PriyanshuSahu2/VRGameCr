using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test : MonoBehaviour
{
    Controls control;
    public InputAction ign;
    Vector2 move;
    private void Awake()
    {
        control = new Controls();
    }
    void Start()
    {
        var input = new InputAction("WASD");
         ign.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/"+GameManager.GM.forward).With("Down", "<Keyboard>/" + GameManager.GM.Backward).With("Left", "<Keyboard>/" + GameManager.GM.Left).With("Right", "<Keyboard>/" + GameManager.GM.Right);
       
        Debug.Log(input);
        ign.Enable();
        ign.performed += OnMove;
        ign.canceled += OnMove;

        //control.Movement.Move.AddCompositeBinding("Dpad").With("Up", "<Keyboard>/W");

    }

    // Update is called once per frame

    private void OnDisable()
    {
        ign.Disable();
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("jeofj");
        move = ign.ReadValue<Vector2>();
        Debug.Log(move);
        Debug.Log($"Move:{move}");
    }
    private void Update()
    {

    }
}
