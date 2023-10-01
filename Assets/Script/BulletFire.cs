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
        Debug.Log("발사");
        GameObject temp = Instantiate(_bullet); //총알 시작 위치 수정하기//뒤에 붙여주는건 자식 클래스로 붙여주라는 코드임 //초기화를 안해주면 프리팹에 설정되어 있는 포지션으로 처음 만들어짐
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
