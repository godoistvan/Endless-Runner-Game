using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExplosionSpawner : MonoBehaviour
{
    public GameObject explosion;
    float lastspawned;
    public float cooldown;
    private movement player;
    public Vector2 cursorpos;
    //public TextMeshProUGUI text;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
    }
    void Update()
    {
        cursorpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire3"))
        {

            if (Time.deltaTime - lastspawned < cooldown)
            {
                return;
            }
            lastspawned = Time.deltaTime;
            Instantiate(explosion, player.transform.position, Quaternion.identity);
            Debug.Log(Time.deltaTime - lastspawned);
            
        }

    }
    public void changecolor()
    {

    }
    public void changetext(string text)
    {

    }

}

