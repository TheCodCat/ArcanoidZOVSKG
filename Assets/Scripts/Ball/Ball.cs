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
    public TimeLineStateBall _timelineStateBall;
    public PauseStateBall _pauseStateBall;
    public GameStateBall _gameStateBall;

    private void Start()
    {
        Rigibody2D = GetComponent<Rigidbody2D>();
        _ballStateMachine = new BallStateMachine();

        _timelineStateBall = new TimeLineStateBall();
        _pauseStateBall = new PauseStateBall(this, _player);
        _gameStateBall = new GameStateBall(this);
        _ballStateMachine.StateInit(_timelineStateBall);
    }
    private void OnEnable()
    {
        GameInput.OnRestartLVL += Restart;
    }
    private void OnDisable()
    {
        GameInput.OnRestartLVL -= Restart;
    }
    private void Update()
    {
        _ballStateMachine._currentBallState.Update();
        //Debug.Log(_ballStateMachine._currentBallState);
    }
    public void RemoveToPoint()
    {
        _ballStateMachine.ShangeState(_pauseStateBall);
        //_ballStateMachine.ShangeState(_gameStateBall);
    }
    public void GameBall()
    {
        _ballStateMachine.ShangeState(_gameStateBall);
    }
    private void Restart()
    {
        Debug.Log("Шар остановился");
        _ballStateMachine.ShangeState(_timelineStateBall);
        Debug.Log(_ballStateMachine._currentBallState);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player.BallCollision();
    }
}
