using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        NotActiove(_player.transform);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public void NotActiove(Transform parent)
    {
        _ball._isActive = false;
        _ball.transform.SetParent(parent);
        _ball.transform.position = (Vector2)parent.position + _ball._offset;
        _ball.Rigibody2D.bodyType = RigidbodyType2D.Kinematic;
        _ball.Rigibody2D.velocity = Vector2.zero;
    }
}
