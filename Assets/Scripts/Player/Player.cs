using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour,IDamage
{
    public float _speed;
    public float _border;
    public float _maxBounceAngle;
    [SerializeField] private int _maxHP;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _startPannel;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Image _hpBar;
    public Rigidbody2D _rb { get; set; }
    private int _hp;
    private Vector2 _moveDirection;

    public Camera Camera => _camera;
    public StateMachine _machine { get; set; }
    public StateTimeine _stateTimeine { get; set; }
    public PauseState _pauseState { get; set; }
    public MoveState _moveState { get; set; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _hp = _maxHP;

        _machine = new StateMachine();

        _stateTimeine = new StateTimeine();
        _pauseState = new PauseState(this);
        _moveState = new MoveState(this);

        _machine.Init(_stateTimeine);
    }
    private void OnEnable()
    {
        GameInput.OnRestartLVL += RestartPlayer;
    }
    private void OnDisable()
    {
        GameInput.OnRestartLVL -= RestartPlayer;
    }

    private void Update()
    {
        _machine.CurrentState.Update();
    }

    public void StartButton()
    {
        _startPannel.SetActive(false);
        _machine.ChangeState(_moveState);
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        float _hpbarf = (float)_hp / (float)_maxHP;
        _hpBar.fillAmount = _hpbarf;
        if(_hp <= 0)
        {
            _hp = _maxHP;
            GameInput.OnRestartLVL?.Invoke();
        }
    }

    public int GetHP()
    {
        return _hp; 
    }

    private void RestartPlayer()
    {
        _machine.ChangeState(_stateTimeine);
    }

    public void BallCollision()
    {
        _audioManager.BallCollision();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            Vector3 _paddlePosition = transform.position;
            Vector2 _contactPosition = collision.GetContact(0).point;

            float _offset = _paddlePosition.x - _contactPosition.x;
            float _wigth = collision.otherCollider.bounds.size.x;

            float _currentAngle = Vector2.SignedAngle(Vector2.up,ball.Rigibody2D.velocity);
            float _bounceAngle = (_offset / _wigth) * _maxBounceAngle;
            float _newAngle = Mathf.Clamp(_currentAngle + _bounceAngle,-_maxBounceAngle,_maxBounceAngle);

            Quaternion _rotate = Quaternion.AngleAxis(_newAngle,Vector3.forward);
            ball.Rigibody2D.velocity = _rotate * Vector2.up * ball.Rigibody2D.velocity.magnitude;
        }
    }
}
