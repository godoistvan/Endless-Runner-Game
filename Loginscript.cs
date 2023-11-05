using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
public class Loginscript : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onloginbuttonclicked()
    {

        StartCoroutine(login());
    }
    IEnumerator login()
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", username.text);
        form.AddField("userPassword", password.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unitylogin/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            if (www.result==UnityWebRequest.Result.Success)
            {
                Debug.Log(username.text);
                Debug.Log(password.text);
                text.text = $"Üdvözöllek {username.text}";
                SceneManager.LoadScene("MenuScene");
            }
        }

    }
}
