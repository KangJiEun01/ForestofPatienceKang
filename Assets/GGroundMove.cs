using UnityEngine;

public class GGroundMove : MonoBehaviour
{
    Vector3 _dir;
    float _speed;
    Vector3 grStart = new Vector3(23.93f, 0, 0);
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += _dir * Time.deltaTime * _speed;
        if (transform.position.x < (-23.97f))
        {
            DeleteGG();
        }
    }
    public void GGInit(Vector3 dir, float speed)
    {
        _dir = dir;
        _speed = speed;
       // Invoke("DeleteGG", 15f);
    }
    void DeleteGG()
    {
        transform.position = grStart;
        //GetComponent<middleground>().GridInst();
        // Destroy(gameObject);
    }
}
