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
        particlesystemrenderer = fireflowersystem.GetComponent<ParticleSystemRenderer>();
        particles = new ParticleSystem.Particle[fireflowersystem.main.maxParticles];

        aliveParticlesCount = fireflowersystem.GetParticles(particles);
    
    
    }

    // Update is called once per frame
    void Update()
    {
        if (FireflowerhasbeenTriggerd)
        {
            for (int i = 0; i < steps; i++)
            {
                particles[i].position = Vector3.Lerp(
                    fireflowersystem.transform.position,
                    new Vector3(Mathf.Cos(baseangle * i) * radius,
                    curve_particle_MoveY.Evaluate(Time.deltaTime),
                    Mathf.Sin(baseangle * i) * radius), lerpspeed);

            }
        }
    }
}
