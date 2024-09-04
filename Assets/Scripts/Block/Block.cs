using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _render;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball)) {
            TakeBlock();
        }
    }
    public virtual void TakeBlock()
    {
    }
    public virtual void Init(Sprite sprite)
    {
        _render.sprite = sprite;
    }
    public virtual void Init(Sprite sprite, int hp)
    {
        _render.sprite = sprite;
    }
    public SpriteRenderer Render()
    { 
         return _render; 
    }
}
