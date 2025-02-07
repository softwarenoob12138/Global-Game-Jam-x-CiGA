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
        // 使用 Mathf.Lerp 进行平滑过渡
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime / smoothTime);
        // 将速度应用到移动上，这里假设在 x 轴方向移动
        transform.position += Vector3.right * currentSpeed * Time.deltaTime;
    }
}
