using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    Transform _test;

    float Time_current;
    float Time_start;
    float Time_Sumcooltime = 3;
    float _speed = 11;

    void Start()
    {
        _test = GetComponent<Transform>();
    }
    void Update()
    {
        Time_current = Time.time - Time_start;
        if (Time_current > Time_Sumcooltime)
        {
            BulletFire1();
            Reset_CoolTime();
        }
    }
    public void BulletFire1()
    {
        Debug.Log("�߻�");
        GameObject temp = Instantiate(_bullet); //�Ѿ� ���� ��ġ �����ϱ�//�ڿ� �ٿ��ִ°� �ڽ� Ŭ������ �ٿ��ֶ�� �ڵ��� //�ʱ�ȭ�� �����ָ� �����տ� �����Ǿ� �ִ� ���������� ó�� �������
        temp.transform.position = _test.transform.position;
        float x = Mathf.Cos(180);
        Vector3 dir = new Vector3(x, 0, 0);
        temp.GetComponent<BulletMove>().Init(dir, _speed);
    }
    void Reset_CoolTime()
    {
        Time_current = Time_Sumcooltime;
        Time_start = Time.time;
    }
}
