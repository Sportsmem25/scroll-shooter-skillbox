using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int enemyDamage;
    [SerializeField] private AudioClip enemyDamageSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthSystem>(out var health))
        {
            if(health.Health > 0)
            {
                SoundManager.instance.PlaySound(enemyDamageSound);
                health.TakeDamage(enemyDamage);
            }
        }
    }
}
