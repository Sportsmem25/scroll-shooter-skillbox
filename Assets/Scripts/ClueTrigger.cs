using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    [SerializeField] private string message;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ClueManager.ClueEvent?.Invoke(message);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ClueManager.disableClueEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
