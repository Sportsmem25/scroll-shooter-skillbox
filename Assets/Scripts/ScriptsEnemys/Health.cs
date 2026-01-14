using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int startingHealth;
    public float ÑurrentHealth { get; private set; }

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] private AudioClip deadSound;

    public UnityEvent OnDeath;
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        ÑurrentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        ÑurrentHealth = Mathf.Clamp(ÑurrentHealth - _damage, 0, startingHealth);

        if (ÑurrentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            EnemyDied();
        }
    }

    private void EnemyDied()
    {
        dead = true;
        anim.SetTrigger("death");
        SoundManager.instance.PlaySound(deadSound);
        OnDeath?.Invoke();
        foreach (Behaviour component in components)
            component.enabled = false;
    }
}