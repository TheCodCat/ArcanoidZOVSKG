using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public Rigidbody2D Rigibody2D { get; private set; }
    public float _force;
    public Vector2 _offset;
    public bool _isActive;
    public Player _player;
    public Vector2 _velosity;
    public float _maxMagnitude;

    public BallStateMachine _ballStateMachine;
    public PauseStateBall _pauseStateBall;
    public GameStateBall _gameStateBall;

    private void Start()
    {
        Rigibody2D = GetComponent<Rigidbody2D>();
        _ballStateMachine = new BallStateMachine();
        _pauseStateBall = new PauseStateBall(this, _player);
        _gameStateBall = new GameStateBall(this);
        _ballStateMachine.StateInit(_pauseStateBall);
    }
    private void Update()
    {
        _ballStateMachine._currentBallState.Update();
    }
    public void Restart()
    {
        _ballStateMachine.ShangeState(_pauseStateBall);
        _ballStateMachine.ShangeState(_gameStateBall);
    }
}
