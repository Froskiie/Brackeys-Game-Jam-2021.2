using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoulCounterHUD : MonoBehaviour
{

    public Transform sprite;

    public TextMeshProUGUI counter;

    public PlayerMain player;

    // Start is called before the first frame update
    void Start()
    {
        counter.text = "none";
    }

    // Update is called once per frame
    void Update()
    {
        sprite.rotation *= Quaternion.Euler(new Vector3(0, 0, 2f)); // Les quaternions peuvent être résumés comme étant des Vector4. Ils sont utilisés dans pour les rotations.
        counter.text = System.Convert.ToString(player.chaosSoulsCounter);
    }
}
