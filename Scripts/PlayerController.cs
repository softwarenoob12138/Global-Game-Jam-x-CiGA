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

    public float acceleration; // 加速度大小
    public float deceleration; // 减速度大小
    public float maxSpeed; // 最大速度

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
                // 当玩家在冰面上不输入速度时，根据减速度平滑减速到 0
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
                // 当玩家在冰面上输入速度时，根据加速度平滑加速或减速
                if ((moveInput > 0 && currentSpeed >= 0))
                {
                    // 同向加速
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
                    // 反向，先减速到 0 再加速
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
            // 当玩家不在冰面上时，正常控制
            currentSpeed = moveInput * moveSpeed;
        }

        // 更新玩家的速度
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

        // 角色朝向问题
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
