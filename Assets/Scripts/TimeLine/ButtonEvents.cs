using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private BallCreator _ball;
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _AudioClip;
    [SerializeField] private AudioSource _AudioSource;
    public void StartSFX()
    {
        _AudioSource.clip = _AudioClip;
        _AudioSource.Play();
    }
    public void ExitTimeLinePlayer()
    {
        if (_ball == null || _player._machine == null) return;

        _player._machine.ChangeState(_player._pauseState);
        _ball.GetBall()._ballStateMachine.ShangeState(_ball.GetBall()._pauseStateBall);
    }
}
