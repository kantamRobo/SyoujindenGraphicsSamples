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

            //パーティクルシステムのレンダラーにアタッチされているマテリアルの
            //光を強める
            
            var particles = new ParticleSystem.Particle[particlesystem.main.maxParticles];
            //寿命を迎えてないパーティクルの速度を上げる
            //注意:パーティクルシステムでこれから出てくるパーティクルの速度を上げるのではなく、
            //生存しているパーティクルの速度を上げる
            int aliveParticlesCount = particlesystem.GetParticles(particles);
            particlesystemrenderer.material.SetColor("_EmissionColor", runningemmisioncolor);
            particlesystem.startLifetime = running_particlelifetime;
            for (int i=0; i < aliveParticlesCount;i++)
            {
                particles[i].velocity = particles[i].velocity.normalized * (particles[i].velocity.magnitude + Time.deltaTime);
                
            }

            particlesystem.SetParticles(particles, aliveParticlesCount);

           
            
        }

        //パーティクルの寿命が来たら
        //particlesystemrenderer.material.SetColor("EmissionColor", temp_emissioncolor);
    }
}
