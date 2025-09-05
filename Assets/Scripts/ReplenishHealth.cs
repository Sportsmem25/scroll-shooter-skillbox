using UnityEngine;

public class ReplenishHealth : MonoBehaviour
{
    [SerializeField] private AudioClip pickUpHealthSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthSystem>(out var health))
        {
            SoundManager.instance.PlaySound(pickUpHealthSound);
            health.PlusHealth();
            Destroy(gameObject);
        }
    }
}
