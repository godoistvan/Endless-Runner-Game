using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestPlayer : MonoBehaviour
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
    public float maxholdjumptime = 0.4f;
    public float holdjumptimer;
    public float jumpgroundtreshold = 1;
    public float distance = 0;
    public BoxCollider2D objectCollider;
    public int health = 150;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("DeadScene");
    }
    void Start()
    {
        objectCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float grounddistance = Mathf.Abs(pos.y - groundHeight);
        if (isgrounded || grounddistance <= jumpgroundtreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
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
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if (!isgrounded)
        {
            if (isholdingjump)
            {
                holdjumptimer += Time.fixedDeltaTime;
                if (holdjumptimer >= maxholdjumptime)
                {
                    isholdingjump = false;
                }
            }
            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isholdingjump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            Vector2 rayorigin = new Vector2(pos.x + 0.8f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2d = Physics2D.Raycast(rayorigin, rayDirection, rayDistance);
            if (hit2d.collider != null)
            {

                TestGround ground = hit2d.collider.GetComponent<TestGround>();
                if (ground != null)
                {
                    groundHeight = ground.groundHeight;
                    pos.y = groundHeight;
                    velocity.y = 0;
                    isgrounded = true;
                }
            }
            Debug.DrawRay(rayorigin, rayDirection * rayDistance, Color.cyan);
        }
        distance += velocity.x * Time.fixedDeltaTime;
        if (isgrounded)
        {
            float velocityratio = velocity.x / maxxvelocity;
            accelaration = maxaccelaration * (1 - velocityratio);
            velocity.x += accelaration * Time.fixedDeltaTime;

            if (velocity.x >= maxxvelocity)
            {
                velocity.x = maxxvelocity;
            }
            Vector2 rayorigin = new Vector2(pos.x, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2d = Physics2D.Raycast(rayorigin, rayDirection, rayDistance);
            if (hit2d.collider != null)
            {
                isgrounded = false;
            }
            Debug.DrawRay(rayorigin, rayDirection * rayDistance, Color.yellow);
        }
        transform.position = pos;
    }

}
