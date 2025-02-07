using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public string levelToLoad;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(waitToRespawn);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        // 未激活任何检查点之前 spawnPoint 默认是(0, 0, 0)

        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;


    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        // PlayerController.instance.stopInput = true;

        CameraController.instance.stopFollow = true;

        // UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        // UIController.instance.FadeToBlack();

        // yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(levelToLoad);
    }

}
