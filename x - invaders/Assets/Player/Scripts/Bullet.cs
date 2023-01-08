using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _flyightSpeed = 7.0f;
    
    void Update()
    {
        Flight();
    }

    private void Flight()
    {
        Vector3 flyightDir = Vector3.up;
        transform.position += flyightDir * _flyightSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.GetDamage(1);
        Destroy(gameObject);
    }
}
