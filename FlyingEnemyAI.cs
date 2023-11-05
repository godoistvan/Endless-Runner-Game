using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
    public int health = 1;
    public GameObject reward;
    public int movespeed = 5;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(reward, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20f, this.transform.position.y),movespeed*Time.deltaTime);
    }
}
