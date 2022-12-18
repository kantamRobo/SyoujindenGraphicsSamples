using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.ParticleSystem;
[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AnimationCurve))]

public class FireflowerEffect : MonoBehaviour
{
    [SerializeField]
    private int aliveParticlesCount;
    [SerializeField]
    private ParticleSystemRenderer particlesystemrenderer;
    [SerializeField]
    private AnimationCurve curve_particle_MoveY;
    [SerializeField]
    private ParticleSystem fireflowersystem;
    [SerializeField]
    private Particle[] particles;
    [SerializeField]
    private static readonly int baseangle = 45;
    [SerializeField]
    private static readonly int steps = 8;
    [SerializeField]
    private static readonly float radius = 0;
    [SerializeField]
    private static readonly float lerpspeed = 0;
    // Start is called before the first frame update
    public bool FireflowerhasbeenTriggerd = false;
       
    void Start()
    {
        //�R���p�C���ł��Ȃ��G���[���o����A�܂��p�[�e�B�N���V�X�e���ƃA�j���[�V�����J�[�u���I�u�W�F�N�g�ɂ��Ă邩�ǂ����m�F����
        particlesystemrenderer = fireflowersystem.GetComponent<ParticleSystemRenderer>();
        particles = new ParticleSystem.Particle[fireflowersystem.main.maxParticles];

        aliveParticlesCount = fireflowersystem.GetParticles(particles);
    
    
    }

    // Update is called once per frame
    void Update()
    {
        //�Ⴆ�΁A���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g���_���[�W���󂯂���
        //�p�[�e�B�N���V�X�e�����쓮����
        if (FireflowerhasbeenTriggerd)
        {
            if (!fireflowersystem.isPlaying)
            {
                fireflowersystem.Play();
                for (int i = 0; i < steps; i++)
                {
                    particles[i].position = Vector3.Lerp(
                        fireflowersystem.transform.position,
                        new Vector3(Mathf.Cos(baseangle * i) * radius,
                        curve_particle_MoveY.Evaluate(Time.deltaTime),
                        Mathf.Sin(baseangle * i) * radius), lerpspeed);
                    Debug.Log("���퓮��");
                }
            }
           
        }
        else
        {

            fireflowersystem.Stop();


        }
    }
}
