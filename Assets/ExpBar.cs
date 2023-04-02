using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainExp : MonoBehaviour
{

    public PlayerStat player;
    public Image FillBar;
    public Text LevelText;

    private float expAmount;

    // Update is called once per frame
    void Update()
    {
        expAmount = player.Exp;
        expFillimage.fillAmount = exp/player.maxExp;
        print(player.Level);
        levelText.text = player.Level.ToString();
    }
}