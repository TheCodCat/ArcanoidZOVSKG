using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

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
    public virtual void Init(Sprite sprite,bool isdestroy)
    {
        _render.sprite = sprite;
    }
    public virtual void Init(Sprite sprite,bool isdestroy, int hp)
    {
        _render.sprite = sprite;
    }
    public SpriteRenderer Render()
    { 
         return _render; 
    }
}
