using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eastereggcoin : MonoBehaviour
{
    private eastereggcoincollect player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<eastereggcoincollect>();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {

        Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag.Equals("Player") == true)
        {
            Destroy(gameObject);
            player.coincollected += 1;
        }
    }
}
