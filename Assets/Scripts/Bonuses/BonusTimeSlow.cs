using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTimeSlow : Bonus
{
    GameControllerScript gameController;

    public override void ActivateBonus()
    {
        gameObject.GetComponentInChildren<Text>().text = duration.ToString();
        gameObject.SetActive(true);
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        gameController.gameSpeed = 0.5f;
        timer = duration;   
        isActive = true;
        Invoke("Countdown", 1);
        Invoke("Deactivatebonus", duration);
    }

    protected override void Deactivatebonus(){
        gameObject.SetActive(false);
        isActive = false;     
        gameController.gameSpeed = 1;   
    }
}
