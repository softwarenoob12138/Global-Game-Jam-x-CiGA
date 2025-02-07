using UnityEngine;
public enum WindType
{
    normal,
    cold,
    hot
}

public class Gun : MonoBehaviour
{
    public static Gun instance;

    public float addForce;

    public Collider2D cd;

    public WindType type;

    public bool getGun;
    public bool getCold;
    public bool getHot;

    public GameObject coldWind, normalWind, hotWind;

    public GameObject coldWindjiantou, normalWindjiantou, hotWindjiantou;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cd.enabled = false;
        coldWind.SetActive(false);
        normalWind.SetActive(false);
        hotWind.SetActive(false);
        coldWindjiantou.SetActive(false);
        normalWindjiantou.SetActive(false);
        hotWindjiantou.SetActive(false);
    }

    private void OnEnable()
    {
        cd.enabled = false;
        type = WindType.normal;
        coldWindjiantou.SetActive(false);
        normalWindjiantou.SetActive(false);
        hotWindjiantou.SetActive(false);
        normalWindjiantou.SetActive(true);
    }

    private void Update()
    {
        if (getGun)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                AudioManager.instance.PlaySFX(3);
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {

                cd.enabled = true;

                if(type == WindType.cold)
                {
                    coldWind.SetActive(true);
                }
                else if(type == WindType.normal)
                {
                    normalWind.SetActive(true);
                }
                else
                {
                    hotWind.SetActive(true);
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                cd.enabled = false;
                coldWind.SetActive(false);
                normalWind.SetActive(false);
                hotWind.SetActive(false);

                AudioManager.instance.StopSFX(3);

            }

            if (getCold && !getHot)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (type == WindType.cold)
                    {
                        type = WindType.normal;
                        coldWindjiantou.SetActive(false);
                        normalWindjiantou.SetActive(true);
                    }
                    else
                    {
                        type = WindType.cold;
                        normalWindjiantou.SetActive(false);
                        coldWindjiantou.SetActive(true);
                    }
                }
            }

            if (getHot)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (type == WindType.cold)
                    {
                        type = WindType.hot;
                        coldWindjiantou.SetActive(false);
                        hotWindjiantou.SetActive(true);

                    }
                    else if (type == WindType.hot)
                    {
                        type = WindType.normal;
                        hotWindjiantou.SetActive(false);
                        normalWindjiantou.SetActive(true);
                    }
                    else
                    {
                        type = WindType.cold;
                        normalWindjiantou.SetActive(false);
                        coldWindjiantou.SetActive(true);
                    }
                }
            }

        }



    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (type == WindType.cold)
        {
            if (other.GetComponent<Bubble>() != null)
            {
                other.GetComponent<Bubble>().isFrozen = true;
                other.GetComponent<Collider2D>().isTrigger = false;
                other.gameObject.layer = 6;
            }

            // �����봥�����������Ƿ�Ϊ����
            if (other.CompareTag("Bubble"))
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // ��ȡ���������ڵ���Ϸ����ı任���
                    //Transform triggerTransform = transform;

                    Vector2 direction = (other.transform.position - transform.position).normalized;

                    // ��ȡ�������� x ��������
                    //Vector3 forceDirection = triggerTransform.right;

                    // ������Ը�����Ҫ����ʩ�ӵ����Ĵ�С������ 10.0f �����Ĵ�С
                    float forceMagnitude = addForce;
                    // ��2D����ʩ�����ķ���
                    rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
                }
            }
        }

        if (type == WindType.normal)
        {
            // �����봥�����������Ƿ�Ϊ����
            if (other.CompareTag("Bubble") && !other.GetComponent<Bubble>().isFrozen)
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // ��ȡ���������ڵ���Ϸ����ı任���
                    //Transform triggerTransform = transform;

                    Vector2 direction = (other.transform.position - transform.position).normalized;

                    // ��ȡ�������� x ��������
                    //Vector3 forceDirection = triggerTransform.right;

                    // ������Ը�����Ҫ����ʩ�ӵ����Ĵ�С������ 10.0f �����Ĵ�С
                    float forceMagnitude = addForce;
                    // ��2D����ʩ�����ķ���
                    rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
                }
            }
        }

        if (type == WindType.hot)
        {
            if (other.GetComponent<Bubble>() != null)
            {
                other.GetComponent<Bubble>().isFrozen = false;
                other.GetComponent<Collider2D>().isTrigger = true;
            }

            // �����봥�����������Ƿ�Ϊ����
            if (other.CompareTag("Bubble"))
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // ��ȡ���������ڵ���Ϸ����ı任���
                    //Transform triggerTransform = transform;

                    Vector2 direction = (other.transform.position - transform.position).normalized;

                    // ��ȡ�������� x ��������
                    //Vector3 forceDirection = triggerTransform.right;

                    // ������Ը�����Ҫ����ʩ�ӵ����Ĵ�С������ 10.0f �����Ĵ�С
                    float forceMagnitude = addForce;
                    // ��2D����ʩ�����ķ���
                    rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
                }
            }
        }
    }
}
