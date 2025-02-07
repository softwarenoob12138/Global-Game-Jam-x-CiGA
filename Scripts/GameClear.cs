using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{

    public bool gameClear;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            UIController.instance.NextStage();
            gameClear = true;
        }
    }

    private void Update()
    {
        if (gameClear)
        {
            PlayerController.instance.transform.gameObject.SetActive(false);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR  // 在编辑器模式退出
        UnityEditor.EditorApplication.isPlaying = false;
#else  // 发布后退出
        Application.Quit();
#endif
    }

}
