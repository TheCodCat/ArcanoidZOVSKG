using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStateMachine
{
    private PauseStateBall PauseStateBall;
    private GameStateBall GameStateBall;

    public BallState _currentBallState;
    public void StateInit(BallState ballState)
    {
        _currentBallState = ballState;
        _currentBallState.Enter();
    }
    public void ShangeState(BallState ballState)
    {
        _currentBallState.Exit();
        _currentBallState = ballState;
        _currentBallState.Enter();
    }
}
