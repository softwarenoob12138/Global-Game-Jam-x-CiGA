using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 这种造成 游戏场景中只有一个 能被点亮的检查点存在
        if (other.CompareTag("Player"))
        {
            CheckPointController.instance.SetSpawnPoint(transform.position);
        }
    }

}
