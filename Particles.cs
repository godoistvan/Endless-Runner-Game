using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem coinparticle;

    // Start is called before the first frame update
    void Start()
    {
        coinparticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
