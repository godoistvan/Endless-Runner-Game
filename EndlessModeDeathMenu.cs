using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class EndlessModeDeathMenu : MonoBehaviour
{
    public TextMeshProUGUI highscoretext;
    public TextMeshProUGUI score;
    public TextMeshProUGUI coin;
    // Start is called before the first frame update
    private void Start()
    {
        highscoretext.text = "Highscore:" + PlayerPrefs.GetInt("highscore");
        score.text = "Score:" + PlayerPrefs.GetInt("score");
        coin.text = "Total coin collected:" + PlayerPrefs.GetInt("coin");
    }

    // Update is called once per frame
    public void Respawn()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
