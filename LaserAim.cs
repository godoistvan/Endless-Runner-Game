using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAim : MonoBehaviour
{
    private Transform player;
    private Transform golem ;
    public float movespeed;
    public GameObject laser;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //laserspawn();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void laserspawn()
    {
        if (player.position.x<0)
        {
            Instantiate(laser, transform.position, Quaternion.Euler(0,0,-130));
            
        }
        if (player.position.x>0)
        {
            Instantiate(laser, transform.position, Quaternion.Euler(0, 0, -27));
        }
        
    }
}
