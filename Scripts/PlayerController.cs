using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;

    public SpriteRenderer sr;

    public GameObject gun;

    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public float groundCheckDistance;

    public float acceleration; // ���ٶȴ�С
    public float deceleration; // ���ٶȴ�С
    public float maxSpeed; // ����ٶ�

    public float currentSpeed;

    private bool onIce;
    private bool onBubble;
    public float minSpeed;

    public Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(Gun.instance.getGun)
        {
            gun.SetActive(true);
        }
        else
        {
            gun.SetActive(false);
        }
    }

    private void OnEnable()
    {
        onBubble = false;

        onIce = false;
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (onIce || onBubble)
        {
            if (moveInput == 0)
            {
                // ������ڱ����ϲ������ٶ�ʱ�����ݼ��ٶ�ƽ�����ٵ� 0
                if (currentSpeed > 0)
                {
                    currentSpeed -= deceleration * Time.deltaTime;
                }
                else if (currentSpeed < 0)
                {
                    currentSpeed += acceleration * Time.deltaTime;
                }
            }
            else
            {
                // ������ڱ����������ٶ�ʱ�����ݼ��ٶ�ƽ�����ٻ����
                if ((moveInput > 0 && currentSpeed >= 0))
                {
                    // ͬ�����
                    currentSpeed += acceleration * Time.deltaTime;
                    if (Mathf.Abs(currentSpeed) > maxSpeed)
                    {
                        currentSpeed = Mathf.Sign(currentSpeed) * maxSpeed;
                    }
                }

                if((moveInput < 0 && currentSpeed <= 0))
                {
                    currentSpeed -= deceleration * Time.deltaTime;
                    if (Mathf.Abs(currentSpeed) < minSpeed)
                    {
                        currentSpeed = Mathf.Sign(currentSpeed) * minSpeed;
                    }
                }
                else
                {
                    // �����ȼ��ٵ� 0 �ټ���
                    if (currentSpeed > 0)
                    {
                        currentSpeed -= deceleration * Time.deltaTime;
                        
                    }
                    else if (currentSpeed <= 0)
                    {
                        currentSpeed += acceleration * Time.deltaTime;
                        
                    }
                }
            }
        }
        else
        {
            // ����Ҳ��ڱ�����ʱ����������
            currentSpeed = moveInput * moveSpeed;
        }

        // ������ҵ��ٶ�
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        if (IsGroundedDetected())
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (IsGroundedDetected())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    // AudioManager.instance.PlaySFX(10);
                }
            }
        }

        // ��ɫ��������
        if (currentSpeed < 0)
        {
            sr.flipX = true; 
        }
        else if (currentSpeed > 0)
        {
            sr.flipX = false; 
        }


        if(rb.velocity.x != 0)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            onIce = true;
        }

        if(other.gameObject.CompareTag("Bubble_P"))
        {
            onBubble = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            StartCoroutine(CanMoveInJumpOnIce());
        }

        if(other.gameObject.CompareTag("Bubble_P"))
        {
            StartCoroutine(CanMoveInJumpOnBubble());
        }
    }



    public bool IsGroundedDetected() => Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPoint.position, new Vector3(groundCheckPoint.position.x, groundCheckPoint.position.y - groundCheckDistance));
    }

    public IEnumerator CanMoveInJumpOnIce()
    {
        yield return new WaitForSeconds(.5f);

        onIce = false;
    }

    public IEnumerator CanMoveInJumpOnBubble()
    {
        yield return new WaitForSeconds(.5f);

        onBubble = false;
    }

}
