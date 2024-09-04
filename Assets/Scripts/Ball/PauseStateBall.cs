using UnityEngine;
using UnityEngine.InputSystem;

public class PauseStateBall : BallState
{
    private Ball _ball;
    private Player _player;
    public PauseStateBall(Ball ball, Player player)
    {
        _ball = ball;
        _player = player;
    }
    public override void Enter()
    {
        Debug.Log("PauseBall");
        NotActiove(_player.transform);
        GameInput.Spaces += Starts;
    }

    public override void Exit()
    {
        Debug.Log("NotPauseBall");
        GameInput.Spaces -= Starts;
    }

    public void NotActiove(Transform parent)
    {
        _ball._isActive = false;
        _ball.transform.SetParent(parent);
        _ball.transform.position = (Vector2)parent.position + _ball._offset;
        _ball.Rigibody2D.bodyType = RigidbodyType2D.Kinematic;
        _ball.Rigibody2D.velocity = Vector2.zero;
    }
    public void Starts(InputAction.CallbackContext context)
    {
        if(context.performed)
            _ball._ballStateMachine.ShangeState(_ball._gameStateBall);
    }
}
