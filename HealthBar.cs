using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Vector3 Offset;
    public Color Low;
    public Color High;
    // Update is called once per frame
    public void SetHealth(float health,float maxhealth)
    {
        Slider.gameObject.SetActive(health < maxhealth);
        Slider.value = health;
        Slider.maxValue = maxhealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
        if (health<=0)
        {
            Slider.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
