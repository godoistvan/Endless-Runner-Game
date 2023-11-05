using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uicontroller : MonoBehaviour
{
    movement player;
    public Text distancetext;
    public Text cointext;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<movement>();
        distancetext = GameObject.Find("DistanceText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        
        int coin = player.totalcoin;
        cointext.text = coin.ToString();
        
        distancetext.text = distance + "m";
    }
}
