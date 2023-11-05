using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class eastereggcoincollect : MonoBehaviour
{
    public int coincollected;
    float lastspawned;
    public float cooldown=15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(load());
    }
    IEnumerator load()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("MenuScene");
    }
}
