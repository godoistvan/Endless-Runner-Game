using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coindrop : MonoBehaviour
{
    public GameObject coin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float number = Random.Range(-13.9f,12.17f);
        Instantiate(coin, new Vector2(number, 8.17f), Quaternion.identity);
    }
}
