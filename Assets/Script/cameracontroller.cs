using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Update()
    {
        Vector3 playerPos = this._player.transform.position;
        if (playerPos.y < 3.7f)
        {
            transform.position = new Vector3(transform.position.x, 3.7f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        }
    }
}
