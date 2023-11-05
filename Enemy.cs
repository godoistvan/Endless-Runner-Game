using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public GameObject spawncoin;
    public GameObject arrow;
    public GameObject arrowparent;
    private movement player1;
    private Transform player;
    public float shootcd=0.1f;
    private float available;
    public bool isalive;
    private void Start()
    {
        player1 = GameObject.Find("Player").GetComponent<movement>();
        Instantiate(arrow, arrowparent.transform.position, Quaternion.Euler(0, 0, -90));

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Die();
        }
    }
    void Update()
    {

        /*
        if (available<Time.time)
        {
            Instantiate(arrow, arrowparent.transform.position, Quaternion.Euler(0,0,-90));
            available = Time.time + shootcd;
        }
        */
        if (this.transform.position.x<-12.52f)
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(-15, this.transform.position.y), player1.velocity.x * Time.deltaTime);
    }
    void Die()
    {
        Instantiate(spawncoin, transform.position, Quaternion.identity);
        Destroy(gameObject,0.2f);
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {

        Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag.Equals("icewall") == true)
        {
            TakeDamage(300);
        }

    }
}
