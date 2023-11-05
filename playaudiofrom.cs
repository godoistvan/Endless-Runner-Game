using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playaudiofrom : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public float playfrom;
    void Start()
    {
        source.time = playfrom;
        source.Play();
        source.SetScheduledEndTime(AudioSettings.dspTime + (14.57f - 13.21f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
