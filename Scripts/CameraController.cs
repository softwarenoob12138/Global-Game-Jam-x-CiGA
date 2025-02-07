using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;

    public Transform farBackground, middleBackground;

    public float minHeight, maxHeight;

    public bool stopFollow;

    private float lastXPos;

    // private float lastYPos;
    private Vector2 lastPos;

    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        // lastXPos = transform.position.x;
        lastPos = transform.position;
    }


    void Update()
    {
        /*
          transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
          float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
          transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        */

        if (!stopFollow)
        {
            // Mathf.Clamp ���� �� transform.position.y ֵ�Ĵ�С�̶��� minHeight �� maxHeight ֮��
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            // float amountToMoveX = transform.position.x - lastXPos;
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            // ����ֻ�� x ���ϸı�λ��
            // ����� Camera ��λ�ò���ֱ�Ӹ��� ���� ,��ô��α 3D �� 2D ����������ͻ���ס Camera ���� ����������
            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);

            // ����Ϸ��������ȣ����м�� ���� һ���Ӳ�Ч������Զ�����ֿ�
            middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

            // lastXPos = transform.position.x;
            lastPos = transform.position;
        }
    }
}
