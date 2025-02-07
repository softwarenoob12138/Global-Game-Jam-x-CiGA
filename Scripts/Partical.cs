using UnityEngine;

public class Partical : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    public float playTime;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        // 立即开始第一次调用PlayParticleSystem方法，之后每隔2秒调用一次
        InvokeRepeating("PlayParticleSystem", 0f, 2f);
    }

    void PlayParticleSystem()
    {
        particleSystem.Play();
        // 0.5秒后停止粒子系统
        Invoke("StopParticleSystem", playTime);
    }

    void StopParticleSystem()
    {
        particleSystem.Stop();
    }
}
