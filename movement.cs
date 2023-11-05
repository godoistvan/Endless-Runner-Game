using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class movement : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float maxaccelaration = 10;
    public float accelaration = 10;
    public float jumpvelocity = 20;
    public float maxxvelocity = 100;
    public float groundHeight;
    public bool isgrounded = false;
    public bool isholdingjump = false;
    public float maxholdjumptime = 0.1f;
    public float maxmaxholdjumptime = 0.2f;
    public float holdjumptimer;
    public float jumpgroundtreshold = 1;
    public float distance = 0;
    public int playerlifes = 3;
    public GameObject deathEffect;
    public float spawnprotection = 5;
    public float lastdeath;
    public GameObject cloud;
    public float health;
    public float maxhealth = 150;
    public HealthBar healthbar;
    public float spawnprotectduration = 2;
    private float isprotected;
    public int totalcoin = 1;
    public GameObject sentry;
    float lastspawned;
    public float cooldown;
    private movement player;
    public Vector2 cursorpos;
    public GameObject damagetaken;
    public Text isimmune;
    public GameObject mechaclone;
    // Start is called before the first frame update
    void Start()
    {
        health = 150;
        healthbar.SetHealth(health, maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (health>maxhealth)
        {
            health -= health-maxhealth;
        }
        Vector2 pos = transform.position;
        float grounddistance = Mathf.Abs(pos.y - groundHeight);
        if (isgrounded||grounddistance<=jumpgroundtreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Instantiate(cloud, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                isgrounded = false;
                velocity.y = jumpvelocity;
                isholdingjump = true;
                holdjumptimer = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isholdingjump = false;
        }
        
        if (Input.GetButtonDown("Fire3"))
        {
            if (lastspawned < Time.time)
            {
                cursorpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(sentry, this.transform.position, Quaternion.identity);
                lastspawned = Time.time + cooldown;
            }
            Debug.Log(Time.deltaTime - lastspawned);
        }

        if (Input.GetButtonDown("Fire4")&& PlayerPrefs.GetString("lastspell")=="hasult")
        {
                PlayerPrefs.SetString("lastspell", "doesnthaveult");
                Instantiate(mechaclone, this.transform.position, Quaternion.identity);
                
        }
        if (health<=0||transform.position.y<-8)
        {
            if (Mathf.FloorToInt(distance)>PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore",Mathf.FloorToInt(distance));
            }
            PlayerPrefs.SetInt("score", Mathf.FloorToInt(distance));
            int getcoin=PlayerPrefs.GetInt("coin");
            PlayerPrefs.SetInt("coin",getcoin+=totalcoin);
            SceneManager.LoadScene("DeadScene");
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position+new Vector3(-0.2f,2,0));
        isimmune.transform.position = screenPos;
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        int layerMask = 1 << 8;
        if (!isgrounded)
        {
            if (isholdingjump)
            {
                holdjumptimer += Time.fixedDeltaTime;
                if (holdjumptimer>=maxholdjumptime)
                {
                    isholdingjump = false;
                }
            }
            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isholdingjump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;    
            }

            Vector2 rayorigin = new Vector2(pos.x + 0.2f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2d = Physics2D.Raycast(rayorigin,rayDirection,rayDistance,layerMask);
            if (hit2d.collider!=null)
            {

                Ground ground = hit2d.collider.GetComponent<Ground>();
                SpawnGround spawnground = hit2d.collider.GetComponent<SpawnGround>();
                if (ground!=null)
                {
                    groundHeight = ground.groundHeight;
                    pos.y = groundHeight;
                    velocity.y = 0;
                    isgrounded = true;
                }
                if (spawnground != null)
                {
                    groundHeight = spawnground.groundHeight;
                    pos.y = groundHeight;
                    velocity.y = 0;
                    isgrounded = true;
                }
                Debug.DrawRay(rayorigin, rayDirection * rayDistance, Color.red);
            }
            
        }
        distance += velocity.x * Time.fixedDeltaTime;

        if (isgrounded)
        {
           //Debug.Log(isgrounded);
            float velocityratio = velocity.x / maxxvelocity;
            accelaration = maxaccelaration * (1 - velocityratio);
            maxholdjumptime = maxmaxholdjumptime * velocityratio;
            velocity.x += accelaration * Time.fixedDeltaTime;
           
            if (velocity.x>=maxxvelocity)
            {
                velocity.x = maxxvelocity;
            }
            Vector2 rayorigin = new Vector2(pos.x-0.2f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2d = Physics2D.Raycast(rayorigin, rayDirection, rayDistance,layerMask);
            if (hit2d.collider == null)
            {
                
                isgrounded = false;
            }
            Debug.DrawRay(rayorigin, rayDirection * rayDistance, Color.red,3);
        }
        /*
        Vector2 rayorigin1 = new Vector2(pos.x + 0.2f, pos.y);
        Vector2 rayDirection1 = Vector2.up;
        float rayDistance1 = velocity.y * Time.fixedDeltaTime;
        RaycastHit2D hit2d1 = Physics2D.Raycast(rayorigin1, rayDirection1,8);
        Debug.DrawRay(rayorigin1, rayDirection1 *1.3f, Color.magenta);
        if (hit2d1.collider!=null)
        {
            if (hit2d1.collider.gameObject.tag.Equals("arrow") == true)
            {


            }
            if (hit2d1.collider.gameObject.tag.Equals("hearth") == true)
            {
                health += 30;
                healthbar.SetHealth(health, maxhealth);
            }
            if (hit2d1.collider.gameObject.tag.Equals("coin") == true)
            {
                totalcoin += 1;

            }
        }

        */
        transform.position = pos;
    }
    IEnumerator spawnprotect()
    {
        yield return isimmune.text = "Immune";
        yield return new WaitForSeconds(2f);
        yield return isimmune.text = "";
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {

        Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag.Equals("arrow") == true)
        {
            if (spawnprotectduration < Time.time)
            {
                Instantiate(damagetaken, this.transform.position, Quaternion.identity);
                spawnprotectduration = Time.time + spawnprotection;
                health -= 30;
                healthbar.SetHealth(health, maxhealth);
                StartCoroutine(spawnprotect());
            }
        }
        if (hitInfo.gameObject.tag.Equals("hearth") == true)
        {
            health += 30;
           
        }
        healthbar.SetHealth(health, maxhealth);
    }
}
