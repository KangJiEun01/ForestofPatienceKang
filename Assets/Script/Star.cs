using UnityEngine;
public class Star : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}