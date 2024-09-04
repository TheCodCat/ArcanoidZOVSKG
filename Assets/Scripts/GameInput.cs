using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static event Action<InputAction.CallbackContext> InputDirection;
    public static event Action<InputAction.CallbackContext> Spaces;
    private PlayerInput inputActions;

    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Enable();

        inputActions.Game.MousePosition.performed += ctx => OnDirection(ctx);

        inputActions.Game.Space.performed += ctx => Space(ctx);
    }
    private void OnDirection(InputAction.CallbackContext context)
    {
        InputDirection?.Invoke(context);
    }

    private void Space(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        Spaces?.Invoke(context);
    }
}
