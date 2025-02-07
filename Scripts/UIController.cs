using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image fadeScreen;

    public float fadeSpeed;

    public bool shouldFadeToBlack, shouldFadeFromBlack;

    [SerializeField] private string sceneName;
    [SerializeField] private string onLevel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        FadeFromBlack();
    }

    void Update()
    {
        if(shouldFadeToBlack)
        {
            // 这段方法中包含的返回值的含义分别是
            // r.红
            // g.绿
            // b.蓝
            // a.透明度

            // Mathf.MoveTowards 该方法用于将一个值向另一个值移动
            // Mathf.MoveTowards(a , b, c)
            // a是要移动的值
            // b是目的值
            // c是值移动的速度

            // 要 * Time.deltaTime 是为了契合不同用户的不同性能配置

            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }

    }


    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void NextStage()
    {
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }

    IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        FadeToBlack();

        yield return new WaitForSeconds(_delay);

        // 使用 LoadScene 方法前确定导入了 UnityEngine.SceneManagement 命名空间
        // 该方法 位于 UnityEngine.SceneManagement 命名空间下的 SceneManager 类中
        SceneManager.LoadScene(sceneName);
    }

    public void LoadStage()
    {
        StartCoroutine(LoadLevelWithFadeEffect(1.5f));
    }

    IEnumerator LoadLevelWithFadeEffect(float _delay)
    {
        FadeToBlack();

        yield return new WaitForSeconds(_delay);

        // 使用 LoadScene 方法前确定导入了 UnityEngine.SceneManagement 命名空间
        // 该方法 位于 UnityEngine.SceneManagement 命名空间下的 SceneManager 类中
        SceneManager.LoadScene(onLevel);
    }

    public void ExitToMainMenu()
    {
        StartCoroutine(ExitWithFadeEffect(1.5f));
    }
    IEnumerator ExitWithFadeEffect(float _delay)
    {
        FadeToBlack();

        yield return new WaitForSeconds(_delay);

        // 使用 LoadScene 方法前确定导入了 UnityEngine.SceneManagement 命名空间
        // 该方法 位于 UnityEngine.SceneManagement 命名空间下的 SceneManager 类中
        SceneManager.LoadScene("MainMenu");
    }
}
