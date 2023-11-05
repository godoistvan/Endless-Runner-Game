using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcewallBehavior : MonoBehaviour
{
    private int health;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        Destroy(gameObject, 3); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Destroy(gameObject);
        }
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {

        Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag.Equals("laser") == true)
        {
            health -= 1000;
        }
        if (hitInfo.gameObject.tag.Equals("Ground") == true)
        {
            Instantiate(particle, new Vector2(transform.position.x,transform.position.y-0.8f), Quaternion.identity);
        }
        
        if (hitInfo.gameObject.tag.Equals("bossprojectile") == true)
        {
            health -= 100;
        }
        if (hitInfo.gameObject.tag.Equals("golem") == true)
        {
            health -= 1000;
        }
        if (hitInfo.gameObject.tag.Equals("clone") == true)
        {
            health -= 50;
        }
        if (hitInfo.gameObject.tag.Equals("Enemy") == true)
        {
            health -= 100;
        }

    }
}
