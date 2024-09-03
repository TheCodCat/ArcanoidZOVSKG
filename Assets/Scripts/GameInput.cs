using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameInput : MonoBehaviour
{
    public static event Action<InputAction.CallbackContext> InputDirection;
    public static event Action<InputAction.CallbackContext> Spaces;
    private PlayerInput inputActions;

    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Enable();

        inputActions.Game.MoveDirection.started += ctx => OnDirection(ctx);
        inputActions.Game.MoveDirection.performed += ctx => OnDirection(ctx);
        inputActions.Game.MoveDirection.canceled += ctx => OnDirection(ctx);

        inputActions.Game.Space.performed += ctx => Space(ctx);
    }
    private void OnDirection(InputAction.CallbackContext context)
    {
        InputDirection?.Invoke(context);
    }

    private void Space(InputAction.CallbackContext context)
    {
        Spaces?.Invoke(context);
    }
}
