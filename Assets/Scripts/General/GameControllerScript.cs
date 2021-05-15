using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    
    public float objectsSpeed;
	public float gameSpeed;
    public bool isEvent;
    public List<GameEvent> events;
    private int currentLevel;
    private float scalePerExp;
    private float currentExp;
    private float requiredExp;
    private GameObject player;
    public GameObject levelFill;
    public Text levelText;

    void Start(){
        currentLevel = 1;
        currentExp = 0;
        requiredExp = 200;
        player = GameObject.FindWithTag("Player");
        isEvent = false;            
    }

    public void AddExp(float exp){
        currentExp += exp;
        levelFill.transform.localScale = new Vector2(levelFill.transform.localScale.x + (exp / requiredExp), levelFill.transform.localScale.y);
        if(currentExp >= requiredExp)
        {
            LevelUp();
        }                
    }

    void LevelUp(){
        currentLevel++;
        requiredExp *= 1.5f;
        levelFill.transform.localScale = new Vector2(currentExp / requiredExp, levelFill.transform.localScale.y);
        levelText.text = "Level: " + currentLevel;
        if(currentLevel == 3)
            player.GetComponent<ShootingScript>().bulletsCount += 1;
        if(currentLevel == 5)
            player.GetComponent<ShootingScript>().bulletsCount += 1;
        if(currentLevel == 6)
            events[0].StartEvent(this);
        if(currentLevel == 7)
            events[1].StartEvent(this);
        if(currentLevel == 8)
            events[2].StartEvent(this);
        if(currentLevel == 9)
            events[3].StartEvent(this);
        
    }

    public int GetLevel(){
        return currentLevel;
    }

    

}
