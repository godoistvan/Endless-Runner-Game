using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBossMovement : MonoBehaviour
{
    private Transform laser;
    public float movespeed = 2;
    public float jumpforce = 1;
    public float health;
    public float maxhealth = 150;
    private Rigidbody2D _rigidbody;
    public HealthBar healthbar;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        laser = GameObject.FindGameObjectWithTag("laser").GetComponent<Transform>();
        health = 150;
        healthbar.SetHealth(health, maxhealth);
        
    }

    
    void Update()
    {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f,0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime*movespeed;
        if (Input.GetButtonDown("Jump")&&Mathf.Abs(_rigidbody.velocity.y)<0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, jumpforce),ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Horizontal")==-1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal")==1)
        {
            transform.rotation = Quaternion.identity;
        }
        healthbar.SetHealth(health, maxhealth);
        if (health <= 0)
        {
            SceneManager.LoadScene("BossDeadScene");
        }

    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {

        Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag.Equals("laser")==true)
        {
            health -= 30;
        }
        if (hitInfo.gameObject.tag.Equals("bossprojectile") == true)
        {
            health -= 10;
        }
        if (hitInfo.gameObject.tag.Equals("golem") == true)
        {
            health -= 50;
        }
        if (hitInfo.gameObject.tag.Equals("clone") == true)
        {
            health -= 10;
        }
        healthbar.SetHealth(health, maxhealth);
    }
}
