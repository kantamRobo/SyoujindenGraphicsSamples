using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;


    public class Particlesystemformoving : MonoBehaviour
    {
    public ThirdPersonController player;

    // Start is called before the first frame update

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
    [SerializeField]
    private float running_particlelifetime = 1.23f;
    Color emissioncolor;
    void Start()
        {
        particlesystemrenderer = particlesystem.GetComponent<ParticleSystemRenderer>();


        emissioncolor = particlesystemrenderer.material.color;
        

    }

    // Update is called once per frame
    void Update()
        {
        var tps_running = (player._input.sprint == true);
        isRunning = tps_running;
        var temp_emissioncolor = Color.Lerp(emissioncolor, endcolor,Time.deltaTime*0.5f);

        if (isRunning)
        {

            //�p�[�e�B�N���V�X�e���̃����_���[�ɃA�^�b�`����Ă���}�e���A����
            //�������߂�
            
            var particles = new ParticleSystem.Particle[particlesystem.main.maxParticles];
            //�������}���ĂȂ��p�[�e�B�N���̑��x���グ��
            //����:�p�[�e�B�N���V�X�e���ł��ꂩ��o�Ă���p�[�e�B�N���̑��x���グ��̂ł͂Ȃ��A
            //�������Ă���p�[�e�B�N���̑��x���グ��
            int aliveParticlesCount = particlesystem.GetParticles(particles);
            particlesystemrenderer.material.SetColor("_EmissionColor", runningemmisioncolor);
            particlesystem.startLifetime = running_particlelifetime;
            for (int i=0; i < aliveParticlesCount;i++)
            {
                particles[i].velocity = particles[i].velocity.normalized * (particles[i].velocity.magnitude + Time.deltaTime);
                
            }

            particlesystem.SetParticles(particles, aliveParticlesCount);

           
            
        }

        //�p�[�e�B�N���̎�����������
        //particlesystemrenderer.material.SetColor("EmissionColor", temp_emissioncolor);
    }
}
