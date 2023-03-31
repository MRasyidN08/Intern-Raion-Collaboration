using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;

    public void LoseHealth(int value)
    {
        //do nothing
        if(health<=0)
            return;
        //reduce the health
        health -= value;
        //refresh the ui fillbar
        fillBar.fillAmount = health / 100;
        //check if your health is zero
        if(health<=0)
        {
            Debug.Log("You Died");
        }
    }

        private void Update()
    {
            if(Input.GetKeyDown(KeyCode.Return))
                LoseHealth(25);
    }
}
