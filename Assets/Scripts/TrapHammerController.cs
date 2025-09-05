using UnityEngine;

public class TrapHammerController : MonoBehaviour
{
    [SerializeField] private int enemyDamage;
    [SerializeField] private float range;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private LayerMask playerLayers;

    private void HammerDamage()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.position, range, playerLayers);
        foreach (Collider2D hitPlayer in  player)
        {
            if (healthSystem.health > 0)
            {
                healthSystem.TakeDamage(enemyDamage);
            }
            else
                return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint.position == null)
            return;
        Gizmos.DrawSphere(attackPoint.position, range);
    }
}
