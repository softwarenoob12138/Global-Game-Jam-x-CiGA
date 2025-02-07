using UnityEngine;

public class Partical : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    public float playTime;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        // ������ʼ��һ�ε���PlayParticleSystem������֮��ÿ��2�����һ��
        InvokeRepeating("PlayParticleSystem", 0f, 2f);
    }

    void PlayParticleSystem()
    {
        particleSystem.Play();
        // 0.5���ֹͣ����ϵͳ
        Invoke("StopParticleSystem", playTime);
    }

    void StopParticleSystem()
    {
        particleSystem.Stop();
    }
}
