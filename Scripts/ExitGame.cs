using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR  // �ڱ༭��ģʽ�˳�
        UnityEditor.EditorApplication.isPlaying = false;
#else  // �������˳�
        Application.Quit();
#endif
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Exit();
        }
            
    }
}
