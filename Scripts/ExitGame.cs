using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR  // 在编辑器模式退出
        UnityEditor.EditorApplication.isPlaying = false;
#else  // 发布后退出
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
