using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject blowPrefab;
  public float minSpawnDelay;
  public float maxSpawnDelay;
  public int requiredLevel;
	public float speed;
  public float health;
  public float expForKill;
  protected bool isEvent;
  protected Camera mainCamera;
  protected GameControllerScript gameController;  

  protected abstract void EnemyMove();
  public abstract bool IsAllowedToSpawn();
  protected virtual void Start()
  {    
    mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    enemyPrefab = gameObject;
    isEvent = gameController.isEvent;
    if(isEvent == true)
    {
      speed = Random.Range(speed, speed * 1.5f);
      expForKill = 0;
    }
  }

  public void DestroyEnemy(){
    GameObject blow = Instantiate(blowPrefab, transform.position, transform.rotation);
      blow.transform.localScale = gameObject.transform.localScale;
      gameController.AddExp(expForKill);
      Destroy(gameObject, 0);      
      Destroy(blow, 0.5f);
  }

  protected virtual void OnTriggerEnter2D(Collider2D col)
  {
    if(col.gameObject.GetComponent<PBullet>()){
      health -= col.gameObject.GetComponent<PBullet>().damage;
      if(health <= 0)
      {
        DestroyEnemy();
      }
      Destroy(col.gameObject, 0);              
    }
  }
}
