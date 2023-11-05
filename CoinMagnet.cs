using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    movement player;
    public int coincollected;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, player.velocity.x*1.2f * Time.deltaTime);
        
        if (this.transform.position==player.transform.position)
        {
            if (this.tag=="hearth")
            {
                player.health += 30;
                player.healthbar.SetHealth(player.health, player.maxhealth);
               
            }
            player.totalcoin += 1;
            Destroy(gameObject);
        }
        
    }
}
