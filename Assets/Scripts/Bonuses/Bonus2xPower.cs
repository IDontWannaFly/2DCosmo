using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus2xPower : Bonus
{
    ShootingScript shooting;
    public override void ActivateBonus()
    {
        gameObject.GetComponentInChildren<Text>().text = duration.ToString();
        gameObject.SetActive(true);
        timer = duration;   
        shooting = GameObject.FindWithTag("Player").GetComponent<ShootingScript>();
        shooting.currentBullet = shooting.bulletPrefabs.Find(bp => bp.gameObject.name == "2xPowerBullet");
        isActive = true;
        Invoke("Countdown", 1);
        Invoke("Deactivatebonus", duration);
    }

    protected override void Deactivatebonus(){
        gameObject.SetActive(false);
        isActive = false;        
        shooting.currentBullet = shooting.bulletPrefabs.Find(bp => bp.gameObject.name == "Bullet");
    }
}
