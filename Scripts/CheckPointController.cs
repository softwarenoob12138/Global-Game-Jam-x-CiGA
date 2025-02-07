using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;

    private CheckPoint[] checkPoints;

    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // FindObjectsOfType 是在整个游戏场景中 找到并获取含有该组件的游戏对象
        // 它只能找到 active 的对象
        checkPoints = FindObjectsOfType<CheckPoint>();

        spawnPoint = PlayerController.instance.transform.position;
    }


    void Update()
    {

    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

}