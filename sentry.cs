using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentry : MonoBehaviour
{
    private movement player;
    private Enemy enemy;
    public GameObject projectile;
    float lastspawned;
    private float shotcooldown;
    public float startshot;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {

        shotcooldown = startshot;
        player = GameObject.Find("Player").GetComponent<movement>();

        Destroy(gameObject, 10);



    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            if (shotcooldown <= 0)
            {
                Instantiate(projectile, this.transform.position, Quaternion.identity);
                shotcooldown = startshot;
            }
            else
            {
                shotcooldown -= Time.deltaTime;
            }

        }
        transform.position = Vector2.MoveTowards(this.transform.position, player.cursorpos, 3 * Time.deltaTime);

    }


}
