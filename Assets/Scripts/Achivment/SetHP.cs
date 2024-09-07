using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SetHP : Achivment
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _head;
    [SerializeField] private ParticleSystem _particleSystem;
    private void FixedUpdate()
    {
        _head.velocity = Vector2.down * _speed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            ParticleSystem _ps = Instantiate(_particleSystem,transform.position,Quaternion.identity,null);
            _ps.Play();
            Destroy(_ps,_ps.main.startLifetime.constant);
        }
            Destroy(gameObject);
    }
}
