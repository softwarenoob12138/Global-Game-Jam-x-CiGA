using UnityEngine;

public class CircleFollowMouse : MonoBehaviour
{
    void Update()
    {
        // ��ȡ�������Ļ�ϵ�λ��
        Vector3 mouseScreenPosition = Input.mousePosition;
        // �����λ��ת��Ϊ��������
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 10f));

        // ��ȡԲ�εĵ�ǰλ��
        Vector3 circlePosition = transform.position;

        // �����Բ��λ�õ��������λ�õ�����
        Vector3 direction = mouseWorldPosition - circlePosition;

        // ������ת�Ƕȣ�����ʹ�� Atan2 ������ z �����ת�Ƕ�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������ת��Ԫ����ֻ�� z ����ת
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        // ����תӦ�õ�Բ�ζ���
        transform.rotation = targetRotation;
    }

}