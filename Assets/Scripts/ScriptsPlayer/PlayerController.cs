using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float m_JumpForce = 400f;                          // Сила прыжка
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = 0.05f;  // Сглаживание движения
    [SerializeField] private bool m_AirControl = false;                         // Может ли игрок управлять персонажем в прыжке
    [SerializeField] private LayerMask m_WhatIsGround;                          // Слой показывающий что является землей для игрока
    [SerializeField] private Transform m_GroundCheck;                           // Позиция показывающая столкнулся ли игрок с землей
    [SerializeField] private Transform firePoint;                               // Позиция выстрела
    [SerializeField] private AudioClip jumpSound;                               // Звук прыжка
    
    private const float GROUNDEDRADIUS = 0.2f;                                 // Радиус круга для определения столкновения с землей
    private bool m_Grounded;                                                    // Проверка на земле ли игрок
    private bool m_FacingRight = true;                                          // Проверка в какую сторону смотрит игрок
    private Vector3 m_Velocity = Vector3.zero;
    private Animator anim;
    private Rigidbody2D rb;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool _wasGrounded = m_Grounded;
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, GROUNDEDRADIUS, m_WhatIsGround);
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!_wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }

    public void Move(float move, bool jump)
    {
        if(m_Grounded || m_AirControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }

            if(m_Grounded && jump)
            {
                m_Grounded = true;
                SoundManager.instance.PlaySound(jumpSound);
                rb.AddForce(new Vector2(0f, m_JumpForce));
            }
        }
    }

    public void DeadPlayer()
    {
        anim.SetTrigger("Dead");
        //this.enabled = false;
        //Time.timeScale = 0;
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        firePoint.transform.Rotate(0f, 180f, 0f);
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
