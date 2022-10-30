using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            particlesystem.startLifetime = running_particlelifetime;
            particlesystemrenderer.material.SetColor("_EmissionColor", runningemmisioncolor);
        }

        //パーティクルの寿命が来たら
        //particlesystemrenderer.material.SetColor("EmissionColor", temp_emissioncolor);
    }
}
