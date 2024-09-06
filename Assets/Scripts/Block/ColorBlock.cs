using UnityEngine;

public class ColorBlock : Block
{
    [SerializeField] private float _currentHP;
    [SerializeField] private float _maxHP;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private bool _isDestroy;
    private Color _currentColor;
    public override void Init(Sprite sprite,bool isDestroy,int hp)
    {
        base.Init(sprite,isDestroy,hp);
        _currentHP = hp;
        _maxHP = hp;
        _isDestroy = isDestroy;
        _currentColor = _defaultColor;
        Render().color = _currentColor;
    }

    public override void TakeBlock()
    {
        if (!_isDestroy) return;

        _currentHP--;
        _currentColor.a = _currentHP / _maxHP;
        Render().color = _currentColor;
        if (_currentHP <= 0)
        {
            BlockManager.OnDestroyBlock?.Invoke(this);
        }
    }
}
