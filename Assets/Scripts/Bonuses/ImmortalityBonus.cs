using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImmortalityBonus : Bonus
{
    private GameObject player;
    public override void ActivateBonus()
    {
        player = GameObject.FindWithTag("Player");
        gameObject.GetComponentInChildren<Text>().text = duration.ToString();
        gameObject.SetActive(true);
        player.GetComponent<SpaceshipScript>().isImmortal = true;
        player.transform.Find("Shield").gameObject.SetActive(true);
        timer = duration;   
        isActive = true;
        Invoke("Countdown", 1);
        Invoke("Deactivatebonus", duration);
    }

    protected override void Deactivatebonus(){
        gameObject.SetActive(false);
        isActive = false;     
        player.GetComponent<SpaceshipScript>().isImmortal = false;
        player.transform.Find("Shield").gameObject.SetActive(false);
    }
}
