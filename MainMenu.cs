using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void MechaGolem()
    {
        SceneManager.LoadScene("GolemBossScene");
    }
    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void EasterEgg()
    {
        SceneManager.LoadScene("BonusScene");
    }
    public void Respawn()
    {
        SceneManager.LoadScene("TestScene");
    }
}
