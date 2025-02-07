using UnityEngine;

public class SmoothSpeedChange : MonoBehaviour
{
    public float initialSpeed = 5f;
    public float targetSpeed = 10f;
    public float smoothTime = 2f;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        // ʹ�� Mathf.Lerp ����ƽ������
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime / smoothTime);
        // ���ٶ�Ӧ�õ��ƶ��ϣ���������� x �᷽���ƶ�
        transform.position += Vector3.right * currentSpeed * Time.deltaTime;
    }
}
