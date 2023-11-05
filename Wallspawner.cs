using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallspawner : MonoBehaviour
{
    
    public GameObject icewall;
    float lastspawned;
    public float cooldown;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(10000);
        }

        Debug.Log(hitInfo.name);
    }
    void Update()
    {
        Vector2 cursorpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time - lastspawned < cooldown)
            {
                return;
            }
            lastspawned = Time.time;
            Instantiate(icewall, new Vector3(cursorpos.x, cursorpos.y, 0), Quaternion.identity);
        }

        }
    }

