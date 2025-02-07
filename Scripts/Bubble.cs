using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float bounceForce;

    private Rigidbody2D rb;

    public float upForce;

    private bool stop;

    public float currentSpeed;

    public float stopTime;

    public bool isFansShutDown;

    public bool isFrozen;

    public SpriteRenderer currentBubble;

    public Sprite normalBubble, IceBubble;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isFansShutDown)
        {
            stopTime = .25f;
        }
    }

    private void Update()
    {
        if (!isFrozen)
        {
            currentBubble.sprite = normalBubble;

            if (!stop)
            {
                rb.velocity = new Vector2(rb.velocity.x, upForce);
            }

            if (rb.velocity.x > 0 && !stop)
            {
                currentSpeed = rb.velocity.x;
                currentSpeed -= 1 * Time.deltaTime;
                rb.velocity = new Vector2(currentSpeed, upForce);

                if (currentSpeed <= 0)
                {
                    rb.velocity = new Vector2(0, upForce);
                }
            }

            if (rb.velocity.x <= 0 && !stop)
            {
                currentSpeed = rb.velocity.x;
                currentSpeed += 1 * Time.deltaTime; ;
                rb.velocity = new Vector2(currentSpeed, upForce);

                if (currentSpeed >= 0)
                {
                    rb.velocity = new Vector2(0, upForce);
                }
            }

            gameObject.layer = 0;
        }

        else
        {

            currentBubble.sprite = IceBubble;

            if (!stop)
            {
                rb.gravityScale = 2f;
            }

            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 检查碰撞的对象是否是玩家
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // 计算从圆形中心到玩家的向量
                Vector2 direction = (other.transform.position - transform.position).normalized;
                // 施加弹开的力
                if (playerRb.velocity.y != 0)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, 0);

                    playerRb.AddForce(direction * bounceForce, ForceMode2D.Impulse);

                }
            }
        }

        if (other.CompareTag("Ground"))
        {
            StartCoroutine(Stop());
        }

        if (other.CompareTag("Bubble") && !other.GetComponent<Bubble>().isFrozen)
        {
            Destroy(other.gameObject);

            AudioManager.instance.PlaySFX(1);

            if (!isFrozen)
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySFX(1);
            }
        }

        if (other.CompareTag("Ice"))
        {
            StartCoroutine(Stop());
            isFrozen = true;
            gameObject.layer = 6;
        }

        if (other.CompareTag("Bubble_P"))
        {
            StartCoroutine(Stop());
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.PlaySFX(0);
        }
    }

    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);

        stop = true;

        rb.velocity = Vector2.zero;

        rb.isKinematic = true;

        if(isFrozen)
        {
            yield return new WaitForSeconds(.25f);
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
