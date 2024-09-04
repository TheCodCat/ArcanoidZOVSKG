using UnityEngine;

public class ColorBlock : Block
{
    [SerializeField] private float _currentHP;
    [SerializeField] private float _maxHP;
    [SerializeField] private Color _defaultColor;
    private Color _currentColor;
    public override void Init(Sprite sprite,int hp)
    {
        base.Init(sprite,hp);
        _currentHP = hp;
        _maxHP = hp;
        _currentColor = _defaultColor;
        Render().color = _currentColor;
    }

    public override void TakeBlock()
    {
        _currentHP--;
        _currentColor.a = _currentHP / _maxHP;
        Render().color = _currentColor;
        if (_currentHP <= 0)
        {
            BlockManager.OnDestroyBlock?.Invoke(this);
        }
    }
}
