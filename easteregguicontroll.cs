using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class easteregguicontroll : MonoBehaviour
{
    eastereggcoincollect player;

    public Text cointext;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<eastereggcoincollect>();

    }

    // Update is called once per frame
    void Update()
    {


        int coin = player.coincollected;
        cointext.text = coin.ToString();
    }
}
