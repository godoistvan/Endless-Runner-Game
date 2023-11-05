using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone : MonoBehaviour
{
    private Transform player;
    public float movespeed;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        flytowards();
    }
    private void flytowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movespeed* Time.deltaTime);
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
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
