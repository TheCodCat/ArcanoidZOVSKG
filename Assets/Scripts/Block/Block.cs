using UnityEngine;
using UnityEngine.Analytics;

public abstract class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private int _currentHP;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball)) {
            TakeBlock();
        }
    }
    public virtual void TakeBlock()
    {
        _currentHP--;
        if (_currentHP <= 0)
        {

            BlockManager.OnDestroyBlock?.Invoke(this);
        }
    }
    public virtual void Init(Sprite sprite,int hp)
    {
        _render.sprite = sprite;
        _currentHP = hp;
    }
}
