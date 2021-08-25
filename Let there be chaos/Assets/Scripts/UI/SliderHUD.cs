using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHUD : MonoBehaviour
{

    public Slider slider;
    public PlayerMain player;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = player.maxHealth;
        slider.minValue = 0;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(slider.value > player.currentHealth+.1)
        {
            slider.value -= .1f;
        }
        else if(slider.value < player.currentHealth)
        {
            slider.value += .1f;
        }
    }
}
