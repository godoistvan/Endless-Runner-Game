using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletprefab;
    private float lastshot;
    public float cooldown;
    public float speed = 100;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(speed);
        }

    }
    void Shoot(float speed)
    {
        Vector3 screenMousePos = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(screenMousePos);
        // Find out the direction between the player and the mouse pointer.
        Vector2 direction = mousePos - (Vector2)transform.position;

        // Normalize the direction and multiply by bullet speed.
        direction.Normalize();
        direction *= speed;
        if (Time.time-lastshot<cooldown)
        {
            return;
        }   
        lastshot = Time.time;
        GameObject bullet = Instantiate(bulletprefab, transform.position, Quaternion.identity);
        bullet.GetComponent<bullet>().Velocity = direction;
    }

}
