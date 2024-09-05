using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _collisionBallclip;

    public void BallCollision()
    {
        _audioSource.clip = _collisionBallclip;
        _audioSource.pitch = Random.Range(0.95f, 1.0f);
        _audioSource.Play();
    }
}
