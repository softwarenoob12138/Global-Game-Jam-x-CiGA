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
        // ������� ��Ϸ������ֻ��һ�� �ܱ������ļ������
        if (other.CompareTag("Player"))
        {
            CheckPointController.instance.SetSpawnPoint(transform.position);
        }
    }

}
