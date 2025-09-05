using UnityEngine;

public class ReplenishmentKeyCard : MonoBehaviour
{
    [SerializeField] private LiftController liftController;
    [SerializeField] private AudioClip soundSetCard;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            liftController.currentQuantityKeyCard += 1;
            SoundManager.instance.PlaySound(soundSetCard);
            Destroy(gameObject);
        }
    }
}