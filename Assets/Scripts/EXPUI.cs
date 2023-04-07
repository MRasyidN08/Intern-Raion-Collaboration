using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPUI : MonoBehaviour
{
    [SerializeField]
    public Image Fillimage;
    public PlayerStat player;
    public float expAmount=0f;
    public float maxExp=1f;

    // Update is called once per frame
    public void GainExp(float value)
    {
        expAmount += value;
        Fillimage.fillAmount = expAmount/maxExp;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Return))
        GainExp(25);
    }
}
