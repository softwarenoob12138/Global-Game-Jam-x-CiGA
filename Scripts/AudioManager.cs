using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  // ��̬���Ե�����

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic;
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

    public void PlaySFX(int soundToPlay)
    {
        // ��ʰȡ��Ʒ����Ч�������������ʹ��Ч�����������
        // pitch ʹ������������
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        soundEffects[soundToPlay].Play();
    }

    public void StopSFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();  
    }
}
