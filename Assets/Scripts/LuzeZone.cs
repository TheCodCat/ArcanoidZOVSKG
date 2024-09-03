using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzeZone : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            ball.Restart();
        }
    }
}
