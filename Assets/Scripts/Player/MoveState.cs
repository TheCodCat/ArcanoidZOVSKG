using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : State
{
    public Vector2 _mousePosition;

    private Vector2 _direction;
    private Player _player;
    public MoveState(Player player)
    {
        _player = player;
    }
    public override void Enter()
    {
        GameInput.InputDirection += GetInputMove;
        _direction = Vector2.zero;

        _direction.x = ((Vector2)_player.Camera.ScreenToWorldPoint(_mousePosition)).x;
        _direction.y = _player._rb.position.y;

        _direction.x = Mathf.Clamp(_direction.x, -_player._border, _player._border);
        _player._rb.MovePosition(Vector2.MoveTowards(_player._rb.position, _direction, _player._speed * Time.deltaTime));
    }

    public override void Exit()
    {
        GameInput.InputDirection -= GetInputMove;
    }

    public override void Update()
    {
        _direction.x = ((Vector2)_player.Camera.ScreenToWorldPoint(_mousePosition)).x;
        _direction.y = _player._rb.position.y;

        _direction.x = Mathf.Clamp(_direction.x, -_player._border, _player._border);
        _player._rb.MovePosition(Vector2.MoveTowards(_player._rb.position,_direction,_player._speed * Time.deltaTime));
    }
    public void GetInputMove(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>();
    }
}
