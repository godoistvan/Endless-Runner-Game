using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    // Start is called before the first frame update
    public float depth = 1;
    movement player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
    }
    void Start()
    { 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realvelocity = player.velocity.x/depth;
        Vector2 pos = transform.position;
        pos.x -= realvelocity * Time.fixedDeltaTime;
        if (pos.x<=-17.11)
        {
            pos.x = 36;
        }
        transform.position = pos;

    }
}
