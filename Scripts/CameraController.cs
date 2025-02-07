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
            // Mathf.Clamp 方法 将 transform.position.y 值的大小固定在 minHeight 和 maxHeight 之间
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            // float amountToMoveX = transform.position.x - lastXPos;
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            // 背景只在 x 轴上改变位置
            // 如果将 Camera 的位置参数直接赋给 背景 ,那么在伪 3D 的 2D 画面里，背景就会贴住 Camera 导致 看不见背景
            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);

            // 让游戏世界有深度，给中间的 背景 一个视差效果，和远景区分开
            middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

            // lastXPos = transform.position.x;
            lastPos = transform.position;
        }
    }
}
