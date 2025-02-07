using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  // 静态属性单例化

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
        // 对拾取物品的音效做随机处理，可以使音效听起来更灵活
        // pitch 使对音调做处理
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        soundEffects[soundToPlay].Play();
    }

    public void StopSFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();  
    }
}
