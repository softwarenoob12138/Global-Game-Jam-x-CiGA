using UnityEngine;

public class CircleFollowMouse : MonoBehaviour
{
    void Update()
    {
        // 获取鼠标在屏幕上的位置
        Vector3 mouseScreenPosition = Input.mousePosition;
        // 将鼠标位置转换为世界坐标
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 10f));

        // 获取圆形的当前位置
        Vector3 circlePosition = transform.position;

        // 计算从圆形位置到鼠标世界位置的向量
        Vector3 direction = mouseWorldPosition - circlePosition;

        // 计算旋转角度，这里使用 Atan2 计算绕 z 轴的旋转角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 创建旋转四元数，只绕 z 轴旋转
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        // 将旋转应用到圆形对象
        transform.rotation = targetRotation;
    }

}