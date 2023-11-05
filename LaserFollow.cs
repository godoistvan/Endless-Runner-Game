using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFollow : MonoBehaviour
{
    private Transform player;
    public float movespeed;
    private float direction;

    public GameObject laserpointleft;
    public GameObject laserpointright;
    private int damage = 50;
    Mechagolem golem;
    public GameObject golemboss;
    // Start is called before the first frame update
    void Awake()
    {
        golem = GameObject.Find("MechaGolem").GetComponent<Mechagolem>();
    }
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Destroy(gameObject, 4);
        
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log(golem.spawnedonleft);
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), movespeed * Time.deltaTime);
        if (golem.spawnedonleft==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), movespeed * Time.deltaTime);
        }
        if (golem.spawnedonright==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), movespeed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        
        Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag.Equals("Player") == true)
        {
           
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag.Equals("icewall") == true)
        {
            Destroy(gameObject);
        }
    }
}
