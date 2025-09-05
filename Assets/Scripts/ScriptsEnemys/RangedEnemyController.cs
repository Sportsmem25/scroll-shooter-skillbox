using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Transform pointAttack;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private HealthSystem hs;
    [SerializeField] private AudioClip shotSound;

    private Animator anim;
    private EnemyPatrol enemyPatrol;
    private float reloadTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        reloadTimer += Time.deltaTime;

        if (PlayerInSignt())
        {
                if (reloadTimer >= attackCooldown && hs.health > 0)
                {
                    reloadTimer = 0;
                    anim.SetTrigger("rangedAttack");
                }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSignt();
    }

    private void RangeAttack()
    {
        SoundManager.instance.PlaySound(shotSound);
        reloadTimer = 0;
        bullets[FindBullet()].transform.position = pointAttack.position;
        bullets[FindBullet()].GetComponent<EnemyBullet>().ActivateEnemyBullet();
    }

    private int FindBullet()
    {
        for( int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSignt()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
