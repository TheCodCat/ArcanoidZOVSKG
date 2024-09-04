using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzeZone : MonoBehaviour
{
    [SerializeField] private Player _playerDamage;
    [SerializeField] private Transform parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            _playerDamage.TakeDamage(1);
            ball.Restart();
        }
    }
}
