using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponDisplayHUD : MonoBehaviour
{

    public TextMeshProUGUI display;

    public PlayerMain player;

    // Start is called before the first frame update
    void Start()
    {
        display.text = "none";
    }

    // Update is called once per frame
    void Update()
    {
        print(player.weapon);
        display.text = System.Convert.ToString(player.weapon);
    }
}
