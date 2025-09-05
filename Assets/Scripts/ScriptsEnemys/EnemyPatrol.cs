using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [SerializeField] private float speed;
    [SerializeField] private float idleDuration;
    
    private float idleTimer;
    private Vector3 initScale;
    private bool movingLeft;


    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("isMoving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void MoveInDirection (int direction)
    {
        idleTimer = 0;
        anim.SetBool("isMoving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
    }

    private void DirectionChange()
    {
        anim.SetBool("isMoving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
}
