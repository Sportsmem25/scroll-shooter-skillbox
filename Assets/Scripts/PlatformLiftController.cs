using UnityEngine;

public class PlatformLiftController : MonoBehaviour
{
    private SliderJoint2D sj;

    private void Start()
    {
        sj = GetComponent<SliderJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sj.useMotor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sj.useMotor = false;
        }
    }
}
