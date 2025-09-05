using UnityEngine;

public class ReplenishmentAmmo : MonoBehaviour
{
    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private AudioClip pickUpAmmoSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(pickUpAmmoSound);
            playerShooting.totalBullet += 30;
        }
        GameObject.Destroy(transform.parent.gameObject);
    }
}
