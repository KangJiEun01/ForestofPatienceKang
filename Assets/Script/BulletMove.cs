using UnityEngine;
public class BulletMove : MonoBehaviour
{
    Vector3 _dir;
    float _speed;
    public void Init(Vector3 dir, float speed)
    {
        _dir = dir;
        _speed = speed;
        Invoke("DeleteBullet", 2f);
    }
    void Update()
    {
        transform.position += _dir * Time.deltaTime * _speed;
    }
    void DeleteBullet()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeleteBullet();
    }
}