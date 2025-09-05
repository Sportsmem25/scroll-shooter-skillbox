using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int startingHealth;
    public float currentHealth { get; private set; }
    public int countScore;
    private Animator anim;
    private bool dead;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] private AudioClip deadSound;

    public static UnityEvent<int> OnEnemyKill = new UnityEvent<int>();

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("death");
                SendEnemyKills(countScore);

                //Deactivate attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
                SoundManager.instance.PlaySound(deadSound);
            }
        }
    }

    public void SendEnemyKills(int countScore)
    {
        OnEnemyKill.Invoke(countScore);
    }
}
