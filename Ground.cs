using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    movement player;
   public  float groundHeight;
    public float groundRight;
    public float screenRight;
     new BoxCollider2D collider;
    bool didgenerateground = false;
    public GameObject enemy;
    public GameObject flyinggold;
    public GameObject flyinghealth;
    public GameObject[] decoration;
    public GameObject archer;
    public bool enemyspawned;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
        collider=GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider.size.y/2);
        screenRight = Camera.main.transform.position.x *2;
    }
    void Start()
    {
        List<float> poslist = new List<float>();
        for (int i = 0; i < 6; i++)
        {
            
            int number = Random.Range(0, 15);
            float number1 = Random.Range(0, 9);
            
            poslist.Add(number1);

                if (number == 12 || number == 13 || number == 14)
                {
                   Instantiate(decoration[number], new Vector2(transform.position.x + number1, this.transform.position.y + (number == 13 ? 1.8f : 2f)), Quaternion.identity);
                    continue;
 
                }
                else
                {
                    Instantiate(decoration[number], new Vector2(transform.position.x + number1, this.transform.position.y + 0.5f), Quaternion.identity);
                }
            


        }
        poslist.Clear();
        int chance = Random.Range(0, 100);
        int chancenumber = 0;
        if (chance == 1)
        {
            Instantiate(flyinggold, flyinggold.transform.position, Quaternion.identity);
        }
        if (player.health<player.maxhealth/2)
        {
            chancenumber = 10;
        }
        else
        {
            chancenumber = 5;
        }
        if (chance <=chancenumber)
        {
            Instantiate(flyinghealth, flyinghealth.transform.position, Quaternion.identity);
        }
        if (chance < 41)
        {
          Instantiate(archer,new Vector2(this.transform.position.x,this.transform.position.y+2), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;


        groundRight = transform.position.x + (collider.size.x / 2);

        if (groundRight < -30)
        {
            Destroy(gameObject);
            return;
        }

        if (!didgenerateground)
        {
            if (groundRight < screenRight)
            {
                didgenerateground = true;
                generateGround();
            }
        }

        transform.position = pos;
    }

    void generateGround()
    {


        GameObject go = Instantiate(gameObject);
        BoxCollider2D goCollider = go.GetComponent<BoxCollider2D>();
        Vector2 pos;

        float h1 = player.jumpvelocity * player.maxholdjumptime; //max magasság amit a játékos ugrani tud
        float t = player.jumpvelocity / -player.gravity; //idõ ami kell ahhoz hogy a player velocity 0 legyen
        float h2 = player.jumpvelocity * t + (0.5f * (player.gravity * (t * t))); //max ugrás space letartás nélkül
        float maxJumpHeight = h1 + h2;
        float maxY = maxJumpHeight * 0.9f;
        maxY += groundHeight;
        float minY = -2.97f;
        float actualY = Random.Range(minY, maxY);

        pos.y = actualY - goCollider.size.y / 2;
        if (pos.y > 4.76f)
            pos.y = 4f;

        float t1 = t + player.maxholdjumptime;
        float t2 = Mathf.Sqrt((2.0f * (maxY - actualY)) / -player.gravity);//az idõ ami a maxy tól az actualy ig esési idõ
        float totalTime = t1 + t2;
        float maxX = totalTime * player.velocity.x;//maximum távolság ahova a játék eltud ugrani az x tengelyen
        maxX *= 0.9f;
        maxX += groundRight;
        float minX = screenRight+3.5f;
        float actualX = Random.Range(minX, maxX);
        pos.x = actualX + goCollider.size.x / 2;
        go.transform.position = pos;

        Ground goGround = go.GetComponent<Ground>();
        goGround.groundHeight = go.transform.position.y + (goCollider.size.y / 2);

    }
}
