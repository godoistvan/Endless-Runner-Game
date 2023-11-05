using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class Mechagolem : MonoBehaviour
{

    private Transform player;
    public float movespeed;
    public GameObject THESQUAD;
    public bool shootinglaser=false;
    public GameObject projectile;
    public GameObject projecttileLeft;
    public GameObject projecttileRight;
    public float shootcd = 2;
    private float available;
    public float impactcd = 5;
    private float impactavailable;
    public GameObject laser;
    public float lasercd = 5;
    private float laseravailable;
    public float clonecd = 5;
    private float cloneavailable;
    public GameObject laserpointleft;
    public GameObject laserpointright;
    public bool spawnedonleft = false;
    public bool spawnedonright = false;
    public float health = 10;
    public float maxhealth = 10;
    private Vector3 impactargetpos;
    private bool dontfly = false;
    public GameObject deatheffect;
    public HealthBar healthbar;
    public GameObject impactparticle;
    private bool isdead = false;
    public GameObject gate;
    public float gatecd = 5;
    private float gateavailable;
    private SpriteRenderer spriteRenderer;
    public Sprite hide;
    void Start()
    {
        health = 1500;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnclones();
        healthbar.SetHealth(health, maxhealth);

       // laserspawn();
        
    }

    
    void Update()
    {
        if (isdead==false)
        {
            if (shootinglaser == false && dontfly == false)
            {
                flytowards();
                if (available < Time.time)
                {
                    if (this.transform.position.x > player.transform.position.x)
                    {
                        Instantiate(projectile, projecttileLeft.transform.position, Quaternion.Euler(0, 0, 90));
                    }
                    if (this.transform.position.x < player.transform.position.x)
                    {
                        Instantiate(projectile, projecttileRight.transform.position, Quaternion.Euler(0, 0, 90));
                    }

                    available = Time.time + shootcd;
                }
            }
            if (laseravailable < Time.time)
            {

                laserspawn();
                laseravailable = Time.time + lasercd;
            }
            if (player.position.x == this.transform.position.x)
            {
                if (impactavailable < Time.time)
                {
                    impactargetpos = player.transform.position;
                    //Debug.Log("Ugyan ott vannak");
                    StartCoroutine(Impact(impactargetpos));
                    impactavailable = Time.time + impactavailable;
                    dontfly = false;
                }
            }
            if (cloneavailable < Time.time)
            {

                spawnclones();
                cloneavailable = Time.time + clonecd;
            }
            //Debug.Log(dontfly);
            healthbar.SetHealth(health, maxhealth);
        }

        if (health<=0)
        {
            
            PlayerPrefs.SetString("lastspell", "hasult");
            spriteRenderer.sprite = hide;
            StartCoroutine(load());
            float randomx = Random.Range(-7.79f,8.10f);
            float randomy = Random.Range(4.15f,-3.2f);
            if (gateavailable < Time.time)
            {
                Instantiate(deatheffect, this.transform.position, Quaternion.identity);
                Instantiate(gate, new Vector2(randomx,randomy), Quaternion.identity);
                gateavailable = Time.time + gatecd;
            }
           

        }
        


    }
    private void flytowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), movespeed * Time.deltaTime);
    }
    private void spawnclones()
    {
        Instantiate(THESQUAD, transform.position, Quaternion.identity);
    }
    public void laserspawn()
    {
        int chance = Random.Range(1, 3);
        if (chance==1)
        {
            Instantiate(laser, new Vector2(11,0), Quaternion.Euler(0, 0, -90));
            spawnedonright = true;
        }
        if (chance==2)
        {
            Instantiate(laser, new Vector2(-10,0), Quaternion.Euler(0, 0, -90));
            
            spawnedonleft = true;
        }
        Debug.Log(chance);
    }
    IEnumerator Impact(Vector3 target)
    {
        dontfly = false;
        while (this.transform.position.y>=-3.36f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.x, -3.50f), movespeed * Time.deltaTime);
            
            yield return dontfly = true; 
        }
        
        //print ("Le zsalt");
        
        yield return new WaitForSeconds(2f);
        Instantiate(impactparticle, transform.position, Quaternion.identity);
        while (this.transform.position.y<=3.44f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 3.45f), movespeed * Time.deltaTime);
            yield return dontfly = false;
        }
        //print("Vissza zsalt");
        

    }
    public void TakeDamage(int damage)
    {
        healthbar.SetHealth(health, maxhealth);
        health -= damage;
        
    }
    IEnumerator load()
    {

        isdead = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("BossKilledScene");
    }
}
