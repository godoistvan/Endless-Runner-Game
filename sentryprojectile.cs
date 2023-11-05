using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryprojectile : MonoBehaviour
{
    public GameObject particle;
    public float movespeed;
    private Transform enemy;
    private Transform sentry;
    private movement player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        Destroy(gameObject, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
            transform.position = Vector2.MoveTowards(this.transform.position, enemy.position, (player.velocity.x*1.1f) * Time.deltaTime);
        }
        else if (GameObject.FindGameObjectWithTag("sentry") != null)
        {
            sentry = GameObject.FindGameObjectWithTag("sentry").transform;
            transform.position = Vector2.MoveTowards(this.transform.position, sentry.position, (player.velocity.x*1.1f) * Time.deltaTime);
        }
        else if (GameObject.FindGameObjectWithTag("sentry") == null)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            enemy.TakeDamage(300);
        }
        Debug.Log(hitInfo.name);
    }

}
