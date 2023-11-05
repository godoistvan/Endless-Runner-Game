using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationMove : MonoBehaviour
{
    movement player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector2.MoveTowards(this.transform.position, new Vector2(-15, this.transform.position.y),player.velocity.x*Time.deltaTime);
        if (this.transform.position.x<=-14.5)
        {
            Destroy(gameObject);
        }
    }
}
