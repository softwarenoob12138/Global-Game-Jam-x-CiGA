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
        // 检查进入触发器的物体是否为泡泡
        if (other.CompareTag("Bubble"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 获取触发器所在的游戏对象的变换组件
                //Transform triggerTransform = transform;

                Vector2 direction = (other.transform.position - transform.position).normalized;

                // 获取触发器的 x 轴正方向
                //Vector3 forceDirection = triggerTransform.right;

                // 这里可以根据需要调整施加的力的大小，例如 10.0f 是力的大小
                float forceMagnitude = addForce;
                // 给2D物体施加力的方法
                rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
            }
        }
    }
}
