using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStateBall : BallState
{
    private Ball _ball;
    public GameStateBall(Ball ball)
    {
        _ball = ball;
    }
    public override void Enter()
    {
        GameInput.Spaces += Active;
    }

    public override void Exit()
    {
        GameInput.Spaces -= Active;
    }

    public override void Update()
    {
        Vector2 _velosity = _ball.Rigibody2D.velocity.normalized * _ball._maxMagnitude;
        if(_velosity.sqrMagnitude >= _ball._velosity.sqrMagnitude)
        {
            _ball.Rigibody2D.velocity = _velosity;
        }
    }

    public void Active(InputAction.CallbackContext context)
    {
        if (context.performed && _ball._isActive == false)
        {
            _ball._isActive = true;
            _ball.transform.SetParent(null);
            _ball.Rigibody2D.bodyType = RigidbodyType2D.Dynamic;
            _ball.Rigibody2D.AddForce(Vector2.up * _ball._force);
        }
    }
}
