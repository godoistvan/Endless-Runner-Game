using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public Vector2 cursorpos;
    public movement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        Destroy(gameObject, 15);
    }

    // Update is called once per frame
    void Update()
    {
        cursorpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(this.transform.position,cursorpos, (player.velocity.x*1.2f) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        FlyingEnemyAI flying = hitInfo.GetComponent<FlyingEnemyAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(1000);
            if (player.health < player.maxhealth)
            {
                player.health += 10;
                player.healthbar.SetHealth(player.health, player.maxhealth);
            }
        }
        if (flying != null)
        {
            flying.TakeDamage(100);
        }
        Debug.Log(hitInfo.name);
    }
}
