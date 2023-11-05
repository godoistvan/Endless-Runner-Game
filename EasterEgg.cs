using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public ParticleSystem coinparticle;


    // Use this for initialization
    void Start()
    {
        coinparticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("executed");


        if (col.gameObject.tag == "megacoin")
        {
            DestroyImmediate(projectile, true);
        }
        //sql add
    }
}