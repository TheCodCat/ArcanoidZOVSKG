using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseState : State
{
    public Player _player;
    public PauseState(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        GameInput.Spaces += StartButton;
    }

    public override void Exit()
    {
        GameInput.Spaces -= StartButton;
    }

    public override void Update()
    {
        base.Update();
    }
    public void StartButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.StartButton();
        }
    }
}
