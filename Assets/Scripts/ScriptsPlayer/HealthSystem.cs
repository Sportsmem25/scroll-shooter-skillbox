using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numberOfLives;
    public Image[] lives;
    public Sprite fullLive;
    public Sprite emptyLive;
    
    [SerializeField] private Behaviour[] components;
    [SerializeField] private AudioClip deadSound;
    [SerializeField] private ScenesController scenesController;
    private PlayerController controller;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }


    void Update()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if(i < health)
                lives[i].sprite = fullLive;
            else
                lives[i].sprite = emptyLive;

            if (i < numberOfLives)
                lives[i].enabled = true;
            else
                lives[i].enabled = false;
        }
    }

    public void PlusHealth()
    {
        health++;
        if(health > numberOfLives)
            health = numberOfLives;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckDamage();
    }

    public void CheckDamage()
    {
        if(health <= 0)
        {
            controller.DeadPlayer();
            foreach (Behaviour component in components)
                component.enabled = false;
            SoundManager.instance.PlaySound(deadSound);
            StartCoroutine(GoToLoseScene());
        }
    }

    IEnumerator GoToLoseScene()
    {
        yield return new WaitForSeconds(3);
        scenesController.LoadLoseScene();
    }
}
