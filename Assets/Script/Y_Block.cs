using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_Block : MonoBehaviour
{
    [SerializeField] Transform _rig;
    [SerializeField] Rigidbody2D _chk;
    [SerializeField] Rigidbody2D _player;

    //Vector2 _bscale;//��ũ��
    //_bscale = transform.localScale;
    //Vector2 _player = this._rig.transform.position;
    //Vector2 _block = transform.position;
    //Vector2 _distance = _block - _player;

    Transform _block;
    bool _upcheck = false;

    bool _UpdatrTrigger = true;
    //   Vector3 moveVector = (_block.position - _rig.position);
    //   Vector3 dirVector = moveVector.normalized;

    Collider2D _triggerCk = new Collider2D();

    void Start()
    {
         _triggerCk = GetComponent <Collider2D>();
        _triggerCk.isTrigger = true; //������ �浹 ���Ҷ��� Ʈ���� ����
        _block = transform;
    }

    void Update()
    {
        //if (_upcheck)
        //{
        //    //float _playerY = _rig.position.y;
        //    //_playerY = this._rig.position.y;
        //    //_chk.bodyType = RigidbodyType2D.Static;
        //}
        if(_upcheck == true)//�浹�ϸ� Ʈ���� ����
        {
            _triggerCk.isTrigger = false;
            //_player.velocity = Vector3.zero;
            _upcheck = false;
            _UpdatrTrigger = false;
        }

        if (_UpdatrTrigger == true)
        {
            _triggerCk.isTrigger = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 moveVector = (_block.position - _rig.position); //������ ���� �Ÿ��� ���̷� ¥����
        //Vector3 dirVector = moveVector.normalized;
        //bool test = dirVector.magnitude > 0;
        float _distans = Vector3.Magnitude(moveVector);
        Debug.Log(_distans);
        if (_distans < 0.6f) {
            Debug.Log("������ �浹");
        }
        else if (_distans > 0.6f&& _distans < 2.3f)
        {
            Debug.Log("������ �浹");
            _upcheck = true;
            //ĳ���� ������ ���߰� ���� �浹
        }
        if (_distans > 2.3f&& _distans<3.0f)
        {
            Debug.Log("���� �浹");
        }
        if (_distans > 3.0f)
        {
            Debug.Log("�Ʒ� �浹");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //�浹 ����� Ʈ���� ����
        Debug.Log("Ʈ���� ����");
        _UpdatrTrigger = true;
    }

}
