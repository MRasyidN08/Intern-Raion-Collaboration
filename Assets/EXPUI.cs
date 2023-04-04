using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GainExp : MonoBehaviour
{

    public Image Fillimage;
    public TextMeshProUGUI TextLevel;
    public PlayerStat player;

    private float expAmount;

    // Update is called once per frame
    void Update()
    {
        expAmount = player.Exp;
        Fillimage.fillAmount = expAmount/player.MaxExp;
        //print(player.Level);
        TextLevel.text = player.Level.ToString();
    }
}
