using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossComponent : MonoBehaviour
{
    public float health;
    protected float currentHealth;    
    protected abstract void HealthIsNull();
    void OnTriggerEnter2D(Collider2D col){
        if(currentHealth > 0)
            if(col.gameObject.GetComponent<PBullet>()){
                currentHealth -= col.gameObject.GetComponent<PBullet>().damage;
                if(currentHealth <= 0)
                {
                    HealthIsNull();
                }
                Destroy(col.gameObject, 0);
            }
    }
}
