using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField] private float speed = 40f;
    [SerializeField] private Animator anim;
    private float horizontalMove = 0f;
    private bool jump;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("isJumping", true);
        }   
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void OnLanding()
    {
        anim.SetBool("isJumping", false);
    }
}
