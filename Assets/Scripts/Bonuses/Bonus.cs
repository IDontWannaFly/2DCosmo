using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bonus : MonoBehaviour
{
    public string bonusName;
    public int duration;
    protected int timer;
    protected bool isActive;

    public abstract void ActivateBonus();

    protected abstract void Deactivatebonus();

    public bool IsActive(){
        return isActive;
    }
    public void Countdown(){
        timer -= 1;
        gameObject.GetComponentInChildren<Text>().text = timer.ToString();
        if(timer > 0)
            Invoke("Countdown", 1);
    }
}
