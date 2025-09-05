using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Text countBullet;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private ScenesController sceneContr;

    public int currentBullet;
    public int totalBullet;
    
    void Update()
    {
        if (sceneContr._iscanShootPlayer)
        {
            if (Input.GetButtonDown("Fire1") && currentBullet > 0)
            {
                anim.SetTrigger("Attack");

            }
        }
        countBullet.text = currentBullet + "/" + totalBullet;

        if(Input.GetKeyDown(KeyCode.R) && totalBullet > 0)
        {
            SoundManager.instance.PlaySound(reloadSound);
            anim.SetTrigger("Recharge");
        }
        Debug.Log(sceneContr._iscanShootPlayer);

        if(currentBullet <= 0)
        {
            currentBullet = 0;
        }
    }

    private void Shoot()
    {
        SoundManager.instance.PlaySound(shotSound);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        currentBullet -= 1;
    }

    private void Reload()
    {
        int reason = 30 - currentBullet;
        if (totalBullet >= reason)
        {
            totalBullet = totalBullet - reason;
            currentBullet = 30;
        }
        else
        {
            currentBullet = currentBullet + totalBullet;
            totalBullet = 0;
        }
    }
}
