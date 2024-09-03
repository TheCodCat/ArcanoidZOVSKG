using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : State
{
    public float _direction;
    private Vector2 _moveDirection;

    private Player _player;
    public MoveState(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        GameInput.InputDirection += GetInputMove;
        _moveDirection.y = _player._rb.position.y;
    }

    public override void Exit()
    {
        GameInput.InputDirection -= GetInputMove;
    }

    public override void Update()
    {
        _moveDirection.x = _player._rb.position.x + _direction * _player._speed * Time.deltaTime;
        _moveDirection.x = Mathf.Clamp(_moveDirection.x, -_player._border, _player._border);
        _player._rb.MovePosition(_moveDirection);
    }
    public void GetInputMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>().x;
    }
}
