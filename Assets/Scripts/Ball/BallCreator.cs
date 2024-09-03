using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Player _player;
    private void Start()
    {
        Ball _myBall = Instantiate(_ball,(Vector2)transform.position,Quaternion.identity,transform);
        _ball = _myBall;
        _ball._player = _player;
    }
    public void Pause()
    {
        _ball._ballStateMachine.ShangeState(_ball._pauseStateBall);
    }
    public void Starts()
    {
        _ball._ballStateMachine.ShangeState(_ball._gameStateBall);
    }
    public Ball GetBall()
    {
        return _ball; 
    }
    public Player GetPlayer()
    {
        return _player;
    }
}
