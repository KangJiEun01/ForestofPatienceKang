using UnityEngine;

public class stg02_cameracontroller : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Update()
    {
        Vector3 playerPos = this._player.transform.position;
        if (playerPos.y > -80.0f)
        {
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -80.0f, transform.position.z);
        }
    }
}
