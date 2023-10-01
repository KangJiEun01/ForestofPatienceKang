using UnityEngine;

public class Player_Controller02 : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rig;
    SpriteRenderer _renderer;

    [SerializeField] GameObject[] _HP;
    [SerializeField] GameObject _gameovertext;

    float _speed = 6.0f;
    float _maxspeed = 9.0f;
    int _jumpCount = 0;
    int HPcount = 0;
    int ClearHP;
    bool _isGround = false;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rig = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();

        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", false);
        _animator.SetBool("Hurt", false);
        _animator.SetBool("Duck", false);
        _animator.SetBool("Skip", false);
        _animator.SetBool("Idle", true);
    }
    void Start()
    {
        _HP[0].SetActive(true);
        _HP[1].SetActive(false);
        _HP[2].SetActive(false);
        _HP[3].SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && (_jumpCount < 3 || _isGround == true))
        {
            JumpUpAni();
            _jumpCount++;
            _rig.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            _isGround = false;
            Debug.Log(_rig.velocity.y);
        }
        if ((_rig.velocity.y < 0) && _isGround == false)
        {
            JumpDownAni();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SkipAni();
            _renderer.flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            IdleAni();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SkipAni();
            _renderer.flipX = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            IdleAni();
        }
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        //if(_rig.velocity.x == 0&& _rig.velocity.y ==0)
        //{
        //    IdleAni();
        //}
        _rig.AddForce(Vector2.right * x * _speed, ForceMode2D.Impulse);
        if (_rig.velocity.x > _maxspeed)
        {
            //SkipAni();
            //_renderer.flipX = false;
            _rig.velocity = new Vector2(_maxspeed, _rig.velocity.y);
        }
        else if (_rig.velocity.x < -_maxspeed)
        {
            //SkipAni();
            //_renderer.flipX = true;
            _rig.velocity = new Vector2(-_maxspeed, _rig.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("jumping"))
        {
            _jumpCount = 0;
            _isGround = true;
        }
        if (collision.collider.CompareTag("hurdle2")) //스테이지3 하단 장애물
        {
            HurtpAni();
            HPcount = 3;
        }
        if (collision.collider.CompareTag("hurdle"))//충돌
        {
            HurtpAni();
            HpUi();
        }
    }
    void HpUi()
    {
        _jumpCount = 0;
        HPcount++;
        HPcount = Mathf.Clamp(HPcount, 0, 3);//최소값 최대값
        if (HPcount == 0)
        {
            _HP[0].SetActive(true);
            _HP[1].SetActive(false);
            _HP[2].SetActive(false);
            _HP[3].SetActive(false);
        }
        else if (HPcount == 1)
        {
            _HP[0].SetActive(false);
            _HP[1].SetActive(true);
            _HP[2].SetActive(false);
            _HP[3].SetActive(false);
        }
        else if (HPcount == 2)
        {
            _HP[0].SetActive(false);
            _HP[1].SetActive(false);
            _HP[2].SetActive(true);
            _HP[3].SetActive(false);
        }
        else if (HPcount == 3)
        {
            _HP[0].SetActive(false);
            _HP[1].SetActive(false);
            _HP[2].SetActive(false);
            _HP[3].SetActive(true);
            CheckGameOver();
        }
    }
    void CheckGameOver()
    {
        if (HPcount == 3)
        {
            _gameovertext.SetActive(true);
            GameManager.Instance.PauseGame();
        }
    }
    void JumpUpAni()
    {
        _animator.SetBool("JumpUp", true);
        _animator.SetBool("JumpDown", false);
        _animator.SetBool("Hurt", false);
        _animator.SetBool("Duck", false);
        _animator.SetBool("Skip", false);
        _animator.SetBool("Idle", false);
    }
    void JumpDownAni()
    {
        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", true);
        _animator.SetBool("Hurt", false);
        _animator.SetBool("Duck", false);
        _animator.SetBool("Skip", false);
        _animator.SetBool("Idle", false);
    }
    void HurtpAni()
    {
        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", false);
        _animator.SetBool("Hurt", true);
        _animator.SetBool("Duck", false);
        _animator.SetBool("Skip", false);
        _animator.SetBool("Idle", false);
    }
    void DuckAni()
    {
        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", false);
        _animator.SetBool("Hurt", false);
        _animator.SetBool("Duck", true);
        _animator.SetBool("Skip", false);
        _animator.SetBool("Idle", false);
    }
    void SkipAni()
    {
        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", false);
        _animator.SetBool("Hurt", false);
        _animator.SetBool("Duck", false);
        _animator.SetBool("Skip", true);
        _animator.SetBool("Idle", false);
    }
    void IdleAni()
    {
        _animator.SetBool("JumpUp", false);
        _animator.SetBool("JumpDown", false);
        _animator.SetBool("Hurt", false);
        _animator.SetBool("Duck", false);
        _animator.SetBool("Skip", false);
        _animator.SetBool("Idle", true);
    }
    public int GetClearDataHp()
    {
        ClearHP = HPcount;
        return ClearHP;
    }
}