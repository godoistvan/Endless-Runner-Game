using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int health = 1;
    GameObject target;
    public float speed;
    Rigidbody2D bullet;
    public int damage = 50;
    private Vector2 playerpos;
    GameObject parent;
    public movement player;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        parent = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        Vector2 movedir = (target.transform.position - transform.position).normalized *speed;
        bullet.velocity = new Vector2(movedir.x, movedir.y);
        Destroy(this.gameObject, 1);
        Debug.Log(target.transform.position+"Target pos");
        Debug.Log(transform.position+"Enemy pos");
    }


        private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.tag.Equals("Player") == true)
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag.Equals("Ground") == true)
        {
            speed = speed / 2;
            //Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag.Equals("bullet") == true)
        {
           
            Destroy(gameObject);
        }
    }
    void Update()
    {
      //  transform.position = Vector2.MoveTowards(this.transform.position, playerpos, speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
}
