using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fans : MonoBehaviour
{
    public static Fans instance;

    public float addForce;

    public Collider2D cd;



    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
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
