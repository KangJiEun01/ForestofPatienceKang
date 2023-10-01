using Unity.VisualScripting;
using UnityEngine;

public class BGroungMove : MonoBehaviour
{
    Vector3 _dir;
    float _speed;
    Vector3 bkStart = new Vector3(18.93f, 0, 0);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _dir * Time.deltaTime * _speed;
        if(transform.position.x < (-28.97f))
        {
            DeleteBG();
        }
    }
    public void BGInit(Vector3 dir, float speed)
    {
        _dir = dir;
        _speed = speed;
       // Invoke("DeleteBG", 15f);
    }
    void DeleteBG()
    {
        transform.position = bkStart;
    }
}
