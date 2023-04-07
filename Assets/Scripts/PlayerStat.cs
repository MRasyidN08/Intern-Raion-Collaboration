using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public PlayerMovement movement;

    //exp
    float exp;
    public float Exp{
        get{ return exp;}
        private set {exp = value;}
    }

    [SerializeField]
    float maxExp=100f;
    public float MaxExp{
        get{return maxExp;}
    }

    [SerializeField]
    int level=1;
    public int Level{
        get{ return level;}
        private set {level = value;}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void die(){
        Debug.Log("You Die");
    }

    void levelUp(){
        this.Level +=1;
        Debug.Log("Level Up");
    }

    public void ApplyExp(int value){
        exp+=value;
        if(exp>=maxExp){
            levelUp();
            exp = exp-maxExp;
        }
        print("current level =" + this.Level + "Current Exp =" + this.Exp);
    }
}
