using UnityEngine;

public class ColorBlock : Block
{
    [SerializeField] private float _currentHP;
    [SerializeField] private float _maxHP;
    [SerializeField] private bool _isDestroy;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private GameObject _setHP;
    [SerializeField] private ParticleSystem _particleSystem;
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
            float rand = Random.value;
            ParticleSystem _ps = Instantiate(_particleSystem,transform.position,Quaternion.identity,null);
            _ps.Play();
            Destroy(_ps.gameObject,_ps.main.startLifetime.constant);
            if(rand <= 0.1)
                Instantiate(_setHP,transform.position,Quaternion.identity,null);

            BlockManager.OnDestroyBlock?.Invoke(this);
        }
    }
}
