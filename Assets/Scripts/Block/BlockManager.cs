using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;


public class BlockManager : MonoBehaviour
{
    public static UnityAction<Block> OnDestroyBlock;
    public static UnityAction OnNewLVL;
    [SerializeField] private BallCreator _ballCreator;
    [SerializeField] private BDBlock _bdBlock;
    [SerializeField] private int _countBlock;
    [SerializeField] private Block _block;
    [SerializeField] private int _defaultCount;
    [SerializeField] private int _maxCount;
    [SerializeField] private Vector2 _offset;
    [Header("Текстура")]
    [SerializeField] private Texture2D _texture;
    [SerializeField] private int _seed;
    [SerializeField] private float _scale;
    [SerializeField] private int _wigth;
    [SerializeField] private int _height;

    private List<Block> _blocksList;
    private ObjectPool<Block> _objectPool;

    private void Start()
    {
        _objectPool = new ObjectPool<Block>(() => Instantiate(_block),
            block => block.gameObject.SetActive(true), 
            block => block.gameObject.SetActive(false),
            block => Destroy(block),
            true, _defaultCount, _maxCount);
        _blocksList = new List<Block>();
        _texture = new Texture2D(_wigth, _height);

        PerlineMap();
        CreateMap(_texture);
    }
    private void OnEnable()
    {
        OnDestroyBlock += DestroedBlock;
        GameInput.OnRestartLVL += RestartLVL;
    }
    private void OnDisable()
    {
        OnDestroyBlock -= DestroedBlock;
        GameInput.OnRestartLVL -= RestartLVL;
    }
    private void PerlineMap()
    {
        for (float y = 0f; y < _height; y++)
        {
            for (float x = 0f; x < _wigth; x++)
            {
                float Px = (_seed + x) / _height * _scale;
                float Py = (_seed + y) / _wigth * _scale;
                float _rezult = Mathf.PerlinNoise(Px, Py);
                Color _newColor = new Color(_rezult, _rezult, _rezult, 1);
                _texture.SetPixel((int)x, (int)y, _newColor);
            }
        }
        _texture.Apply();
    }

    private void CreateMap(Texture2D texture2D)
    {
        for (int y = 0; y < texture2D.height; y++)
        {
            for (int x = 0; x < texture2D.width; x++)
            {
                Block _myBlock = _objectPool.Get();
                _myBlock.name = $"Block{x}{y}";
                _myBlock.transform.SetParent(transform);
                _myBlock.transform.position = new Vector3(((_wigth-1) * 0.5f-x) * _offset.x, ((_height - 1) * 0.5f - y) * _offset.y, 0) + transform.position;
                Color _grad = _texture.GetPixel(x,y);
                int _indexBlock;
                if(_grad.r >=0 && _grad.r < 0.5)
                {
                    _indexBlock = 0;
                }
                else if(_grad.r >= 0.5 && _grad.r <= 0.7)
                {
                    _indexBlock = 1;
                }
                else
                {
                    _indexBlock = 2;
                }
                _myBlock.Init(_bdBlock.blocks[_indexBlock].spritesHP, _bdBlock.blocks[_indexBlock].IsDestroy, _bdBlock.blocks[_indexBlock].HP);

                if (_bdBlock.blocks[_indexBlock].IsDestroy)
                    _countBlock++;
                else _blocksList.Add(_myBlock);
            }
        }
    }

    private void DestroedBlock(Block block)
    {
        _objectPool.Release(block);
        _countBlock--;
        if(_countBlock <= 0)
        {
            for (int i = 0; i < _blocksList.Count; i++)
            {
                _objectPool.Release(_blocksList[i]);
            }
            _blocksList.Clear();
            OnNewLVL?.Invoke();
            var ball = _ballCreator.GetBall();
            ball.RemoveToPoint();
            ball.GameBall();
            _scale += 1;
            PerlineMap();
            CreateMap(_texture);
        }
    }

    private void RestartLVL()
    {
        _scale = 0;
        CreateMap(_texture);
    }
}
