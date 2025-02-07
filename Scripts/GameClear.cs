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
#if UNITY_EDITOR  // �ڱ༭��ģʽ�˳�
        UnityEditor.EditorApplication.isPlaying = false;
#else  // �������˳�
        Application.Quit();
#endif
    }

}
