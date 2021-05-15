using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BCCabin : BossComponent
{
    public Sprite[] phasesSprite;
    private bool isDestroyed;
    protected BossControllerScript bossController;

    void Start(){
        bossController = gameObject.GetComponentInParent<BossControllerScript>();
        currentHealth = health;
    }
    sealed protected override void HealthIsNull(){
        if(isDestroyed == false){
            isDestroyed = true;
            bossController.CabinDestroyed(gameObject);
            UseProtection();
        }
    }

    public bool IsDestroyed(){
        return isDestroyed;
    }

    private void UseProtection(){

    }
}
