using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MGroundMove : MonoBehaviour
{
    Vector3 _dir;
    float _speed;
    Vector3 miStart = new Vector3(24.93f, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _dir * Time.deltaTime * _speed;
        if (transform.position.x < (-22.97f))
        {
            DeleteMG();
        }
    }
    public void MGInit(Vector3 dir, float speed)
    {
        _dir = dir;
        _speed = speed;
        //Invoke("DeleteMG", 15f);
    }
    void DeleteMG()
    {
        transform.position = miStart;
    }
}
