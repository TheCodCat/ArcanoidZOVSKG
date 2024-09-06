using UnityEngine;

public class LuzeZone : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            Debug.Log(_player.GetHP());
            if (_player.GetHP() > 0)
            {
                ball.RemoveToPoint();
                ball.GameBall();
                _player.TakeDamage(1);
            }
            Debug.Log(_player.GetHP());
        }
    }
}
