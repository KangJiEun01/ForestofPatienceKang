using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rig;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject[] _HP;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private float _speed;

    private bool _isGround = false;
    private int _jumpingCount = 0;
    private int _HPCount = 0;
    private void Start()
    {
        InitializeHP();
    }
    private void Update()
    {
        HandleInput();
        CheckGameOver();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void InitializeHP()
    {
        for (int i = 0; i < _HP.Length; i++)
        {
            _HP[i].SetActive(i == 0);
        }
    }
    private void HandleInput()
    {
        IdleRendererX();
        JumpingBool();
        JumpAnimatorY();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpingSp();
        }
    }
    private void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal") * _speed;
        _rig.velocity = new Vector2(x, _rig.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("jumping"))
        {
            _jumpingCount = 0;
            _isGround = true;
            _animator.Play("Player_Idle_Animation");
        }
        else if (collision.collider.CompareTag("hurdle2") || collision.collider.CompareTag("hurdle"))
        {
            HandleHurdleCollision();
        }
    }
    private void HandleHurdleCollision()
    {
        _animator.PlayInFixedTime("Player_hurt_Animation");
        _HPCount++;
        _HPCount = Mathf.Clamp(_HPCount, 0, 3);//변수값 제한

        for (int i = 0; i < _HP.Length; i++)
        {
            _HP[i].SetActive(i == _HPCount);
        }
    }
    private void IdleRendererX()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animator.Play("Player_Skip_Animation");
            _renderer.flipX = Input.GetKeyDown(KeyCode.LeftArrow);
        }
    }
    private void JumpAnimatorY()
    {
        if ((_rig.velocity.y > 0) && (!_isGround))
        {
            _animator.Play("Player_jump_Animation");
        }
        else if ((_rig.velocity.y < 0) && (!_isGround))
        {
            _animator.Play("Player_jumpdown_Animation");
        }
        else if (Time.time > 0.5f)
        {
            // _animator.Play("Player_Idle_Animation");
        }
    }
    private void JumpingBool()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpingCount++;
            if (_jumpingCount < 3)
            {
                _rig.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
                _isGround = false;
            }
        }
    }
    private void JumpingSp()
    {
        _isGround = false;
    }
    private void CheckGameOver()
    {
        if (_HPCount >= 3)
        {
            _gameOverText.SetActive(true);
            GameManager.Instance.PauseGame();
        }
    }
    public int GetClearDataHp()
    {
        return _HPCount;
    }
    private void StarCheck()
    {
       
    }
}