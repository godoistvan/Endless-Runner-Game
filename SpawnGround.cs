using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    // Start is called before the first frame update
    public float groundHeight;
    new BoxCollider2D collider;
    movement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
        collider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider.size.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(-30, this.transform.position.y), player.velocity.x * Time.deltaTime);
        if (this.transform.position.x <= -29.9)
        {
            Destroy(gameObject);
        }
    }
}
