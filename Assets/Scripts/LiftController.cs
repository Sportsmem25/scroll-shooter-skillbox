using UnityEngine;

public class LiftController : MonoBehaviour
{
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private Transform target3;
    [SerializeField] private AudioSource source;
    [SerializeField] private Collider2D coll;

    public bool isLiftTrigger = false;
    public int currentQuantityKeyCard;
    private Rigidbody2D rb;
    private SliderJoint2D sj;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SliderJoint2D>();
    }

    void Update()
    {
        if (currentQuantityKeyCard == 3)
            coll.enabled = true;
        switch (currentQuantityKeyCard)
        {
            case 1:
                MovementLift();
                break;

            case 2:
                MovementLift();
                break;

            case 3:
                MovementLift();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && currentQuantityKeyCard == 2)
        {
            isLiftTrigger = false;
        }
        else if (collision.gameObject.CompareTag("Player") && currentQuantityKeyCard == 3)
        {
            isLiftTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && currentQuantityKeyCard == 2)
            coll.enabled = false;
    }

    private void MovementLift()
    {
        if (isLiftTrigger == false)
        {
            Debug.Log("lift moving");
            rb.bodyType = RigidbodyType2D.Dynamic;
            sj.useMotor = true;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
            sj.useMotor = false;
        }
    }
}
