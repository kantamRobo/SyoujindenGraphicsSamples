using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FireFlowerPlayer : MonoBehaviour
{
    public bool triggerdDamage = false;
    public ParticleSystem fireflowersystem;
    [SerializeField]
    private Particle[] particles;
    [SerializeField]
    private float time;
    [SerializeField]
    private float defaulttime;
    // Start is called before the first frame update
    void Start()
    {
        time = defaulttime;
        particles = new ParticleSystem.Particle[fireflowersystem.main.maxParticles];
        
    }

    // Update is called once per frame
    void Update()
    {
       
       if(triggerdDamage)
        {
            if(!fireflowersystem.isPlaying)
            {
                fireflowersystem.Play();
               
            }
          
            if(fireflowersystem.isPlaying)
            {
                time -= Time.deltaTime;
            }
                if (particles[particles.Length-1].startLifetime>time)
                {
                fireflowersystem.Stop();
                triggerdDamage = false;
                time = defaulttime;
                }
                    
            
        }
    }
}
