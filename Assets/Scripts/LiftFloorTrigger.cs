using UnityEngine;

public class LiftFloorTrigger : MonoBehaviour
{
    [SerializeField] private LiftController liftContr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Lift"))
        {
            liftContr.IsLiftTrigger = true;
            gameObject.SetActive(false);
        }
    }
}
