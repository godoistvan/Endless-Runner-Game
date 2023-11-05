using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;
    public Vector3 Velocity;
    public GameObject particle;
    public movement player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        Destroy(gameObject, 2);

    }
    private void Update()
    {
        transform.position += Velocity * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        FlyingEnemyAI flying = hitInfo.GetComponent<FlyingEnemyAI>();
        clone clonemob = hitInfo.GetComponent<clone>();
        Mechagolem golem = hitInfo.GetComponent<Mechagolem>();
        Ground ground = hitInfo.GetComponent<Ground>();
        random coin = hitInfo.GetComponent<random>();
        EnemyBullet arrow = hitInfo.GetComponent<EnemyBullet>();
        if (enemy != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            enemy.TakeDamage(300);
            if (player.health<player.maxhealth)
            {
                player.health += 10;
                player.healthbar.SetHealth(player.health, player.maxhealth);
            }
            
        }
        if (flying != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            flying.TakeDamage(damage);
        }
        if (clonemob != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            clonemob.TakeDamage(damage);
        }
        if (golem != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            golem.TakeDamage(50);
        }
        if (ground != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (ground != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (coin != null)
        {
            SceneManager.LoadScene("AnotherEasterEggScene");
        }
        Debug.Log(hitInfo.name);
    }

    // Update is called once per frame
}
