using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _render;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball)) {
            TakeBlock();
        }
    }
    public virtual void TakeBlock()
    {
    }
    public void Init(Color color)
    {
        _render.color = color;
    }
}
