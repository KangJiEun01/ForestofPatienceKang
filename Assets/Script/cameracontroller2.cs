using UnityEngine;

public class cameracontroller2 : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Update()
    {
        Vector3 playerPos = this._player.transform.position;
        if (playerPos.x < 1.5f)
        {
            transform.position = new Vector3(1.5f, 3.7f, -10.0f);
        }
        else
        {
            transform.position = new Vector3(playerPos.x, 3.7f, -10.0f);
        }
    }
}
