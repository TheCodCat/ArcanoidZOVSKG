using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static UnityAction OnRestartLVL;
    public static event Action<InputAction.CallbackContext> InputDirection;
    public static event Action<InputAction.CallbackContext> Spaces;
    public static event Action<InputAction.CallbackContext> Restart;
    private PlayerInput inputActions;

    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Enable();

        inputActions.Game.MousePosition.performed += ctx => OnDirection(ctx);

        inputActions.Game.Space.performed += ctx => Space(ctx);
        inputActions.Game.Restart.performed += ctx => Restarts(ctx);
    }
    private void OnDirection(InputAction.CallbackContext context)
    {
        InputDirection?.Invoke(context);
    }

    private void Space(InputAction.CallbackContext context)
    {
        Spaces?.Invoke(context);
    }
    private void Restarts(InputAction.CallbackContext context)
    {
        Restart?.Invoke(context);
    }
}
