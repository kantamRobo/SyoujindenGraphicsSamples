using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;


    public class Particlesystemformoving : MonoBehaviour
    {
    public ThirdPersonController playertpscontroller;

    // Start is called before the first frame update
    [SerializeField]
    private Transform playertransform;
    [SerializeField]
    private bool isRunning;
    [SerializeField]
    private ParticleSystem particlesystem;
    [SerializeField]
    private ParticleSystemRenderer particlesystemrenderer;
    
    [ColorUsage(false, false)]
    public Color endcolor;
    [ColorUsage(false, false)]
    public Color runningemmisioncolor;
    [ColorUsage(false, false)]
    public Color walkingingemmisioncolor;
    [SerializeField]
    private float running_particlelifetime = 1.23f;
    Color emissioncolor;
    [SerializeField]
    private Quaternion particlesystem_rotation;
    [SerializeField]
    private readonly float runningspeed = 2.0f;
    [SerializeField]
    private readonly float walkingspeed = 1.0f;
    [SerializeField]
    private  int aliveParticlesCount;
    [SerializeField]
    Particle[] particles;
    void Start()
        {
        particlesystemrenderer = particlesystem.GetComponent<ParticleSystemRenderer>();


        emissioncolor = particlesystemrenderer.material.color;
        particles = new ParticleSystem.Particle[particlesystem.main.maxParticles];

        aliveParticlesCount = particlesystem.GetParticles(particles);
    }

    // Update is called once per frame
    void Update()
        {
        if (playertpscontroller._input.move.magnitude >0.01f)
        {
            if (!particlesystem.isPlaying)
            {
                particlesystem.Play();
                
            }
            
        }
        else 
        {


            

                particlesystem.Stop();
            
            
        }

        //�������}���ĂȂ��p�[�e�B�N���̑��x���グ��
        //����:�p�[�e�B�N���V�X�e���ł��ꂩ��o�Ă���p�[�e�B�N���̑��x���グ��̂ł͂Ȃ��A
        //�������Ă���p�[�e�B�N���̑��x���グ��
        int aliveParticlesCount = particlesystem.GetParticles(particles);
        particlesystemrenderer.material.SetColor("_EmissionColor", walkingingemmisioncolor);
       


        var tps_running = (playertpscontroller._input.sprint == true);
        isRunning = tps_running;
        var temp_emissioncolor = Color.Lerp(emissioncolor, endcolor,Time.deltaTime*0.5f);
        
        
        for (int i = 0; i < aliveParticlesCount; i++)
        {
            particles[i].velocity = particles[i].velocity.normalized * (particles[i].velocity.magnitude + walkingspeed);
            particles[i].remainingLifetime -= Time.deltaTime;
            if (particles[i].remainingLifetime > 1.0f)
            {
                particlesystemrenderer.material.SetColor("_EmissionColor", Color.Lerp(runningemmisioncolor, endcolor, Time.deltaTime * runningspeed));
            }
        }
        if (isRunning)
        {

            //�p�[�e�B�N���V�X�e���̃����_���[�ɃA�^�b�`����Ă���}�e���A����
            //�������߂�
            
            //�������}���ĂȂ��p�[�e�B�N���̑��x���グ��
            //����:�p�[�e�B�N���V�X�e���ł��ꂩ��o�Ă���p�[�e�B�N���̑��x���グ��̂ł͂Ȃ��A
            //�������Ă���p�[�e�B�N���̑��x���グ��
            
            particlesystemrenderer.material.SetColor("_EmissionColor", runningemmisioncolor);
            //particlesystem.startLifetime = running_particlelifetime;
            
            for (int i=0; i < aliveParticlesCount;i++)
            {
                particles[i].velocity = particles[i].velocity.normalized * (particles[i].velocity.magnitude);
                if (particles[i].remainingLifetime >0.5f)
                {
                    particlesystemrenderer.material.SetColor("_EmissionColor", Color.Lerp(runningemmisioncolor,endcolor,Time.deltaTime*runningspeed));
                }
            }

            particlesystem.SetParticles(particles, aliveParticlesCount);

           
            
        }

        //�p�[�e�B�N���̎�����������
        //particlesystemrenderer.material.SetColor("EmissionColor", temp_emissioncolor);
    }
}
