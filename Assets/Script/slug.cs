using UnityEngine;

public class slug : MonoBehaviour
{
    SpriteRenderer slugren;

    float _speed = 3;
    float x = Mathf.Cos(180);
    int z = 0;
    void Start()
    {
        slugren = GetComponent<SpriteRenderer>();
        slugren.flipX = false;
    }
    void Update()
    {
        slugmove();
    }
    void slugmove()
    {
        Vector3 _dir = new Vector3(x, 0, 0);
        transform.position += _dir * Time.deltaTime * _speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Grid") || (collision.collider.CompareTag("hurdle")))
        {
            if (z == 0)
            {
                x = Mathf.Cos(0);
                slugren.flipX = true;
                z = 1;
            }
            else
            {
                x = Mathf.Cos(180);
                slugren.flipX = false;
                z = 0;
            }
        }
    }
}
