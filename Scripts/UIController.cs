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
            // ��η����а����ķ���ֵ�ĺ���ֱ���
            // r.��
            // g.��
            // b.��
            // a.͸����

            // Mathf.MoveTowards �÷������ڽ�һ��ֵ����һ��ֵ�ƶ�
            // Mathf.MoveTowards(a , b, c)
            // a��Ҫ�ƶ���ֵ
            // b��Ŀ��ֵ
            // c��ֵ�ƶ����ٶ�

            // Ҫ * Time.deltaTime ��Ϊ�����ϲ�ͬ�û��Ĳ�ͬ��������

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

        // ʹ�� LoadScene ����ǰȷ�������� UnityEngine.SceneManagement �����ռ�
        // �÷��� λ�� UnityEngine.SceneManagement �����ռ��µ� SceneManager ����
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

        // ʹ�� LoadScene ����ǰȷ�������� UnityEngine.SceneManagement �����ռ�
        // �÷��� λ�� UnityEngine.SceneManagement �����ռ��µ� SceneManager ����
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

        // ʹ�� LoadScene ����ǰȷ�������� UnityEngine.SceneManagement �����ռ�
        // �÷��� λ�� UnityEngine.SceneManagement �����ռ��µ� SceneManager ����
        SceneManager.LoadScene("MainMenu");
    }
}
