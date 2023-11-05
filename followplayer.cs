using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public movement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
