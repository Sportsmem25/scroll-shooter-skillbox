using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [SerializeField] private int scoreValue;
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDeath.AddListener(OnEnemyDeath);
    }

    private void OnDestroy()
    {
        health.OnDeath.RemoveListener(OnEnemyDeath);
    }

    private void OnDisable()
    {
        health.OnDeath.RemoveListener(OnEnemyDeath);
    }

    private void OnEnemyDeath()
    {
        ScoreCount.AddScore(scoreValue);
        Debug.Log("Очков за этого врага: " + scoreValue);
    }
}
