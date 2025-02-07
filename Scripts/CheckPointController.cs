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
        // FindObjectsOfType ����������Ϸ������ �ҵ�����ȡ���и��������Ϸ����
        // ��ֻ���ҵ� active �Ķ���
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