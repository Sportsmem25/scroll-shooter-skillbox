using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    [SerializeField] private Rigidbody2D rbBullet;
    [SerializeField] private int damage;

    private void Start()
    {
        rbBullet.velocity = transform.right * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var healthenemy))
        {
            healthenemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
