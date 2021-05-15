using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public List<Bonus> bonuses;	
    public float health;
    public bool isImmortal;
    private float currentHealth;	
	public List<string> upgrades;   
    public GameObject healthBar;
    private float startHealthBarScale;

    void Start(){
        currentHealth = health;
        startHealthBarScale = healthBar.transform.localScale.x;
    }

    void TakeDamage(float damage)     
    {
        currentHealth -= damage;
        healthBar.transform.localScale = new Vector2(startHealthBarScale * (currentHealth / health), healthBar.transform.localScale.y);
    }

    public void TakeHeal(float heal)
    {
        currentHealth += heal;
        currentHealth = currentHealth > health ? health : currentHealth;
        healthBar.transform.localScale = new Vector2(startHealthBarScale * (currentHealth / health), healthBar.transform.localScale.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bonus")
        {
            string bonusName = col.gameObject.name;
            bonuses.Find(b => b.bonusName == bonusName.Remove(bonusName.Length - 7)).ActivateBonus();
            Destroy(col.gameObject);
        }
        if(isImmortal == false)
        {
            if(col.gameObject.GetComponent<EBullet>())
            {
                TakeDamage(col.gameObject.GetComponent<EBullet>().damage);
                if(currentHealth <= 0)
                    Destroy(gameObject, 0);
            }
            if(col.gameObject.GetComponent<Enemy>())
            {
                TakeDamage(10);
                if(currentHealth <= 0)
                    Destroy(gameObject, 0);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {        
    }
}


