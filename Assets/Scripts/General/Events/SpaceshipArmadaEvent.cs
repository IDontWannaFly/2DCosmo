using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipArmadaEvent : GameEvent
{
    public override void StartEvent(GameControllerScript gameController){  
        enemySpawner = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>();
        this.gameController = gameController;
        this.gameController.isEvent = true;
        isGoing = true;
        enemySpawner.StopAllCoroutines();
        enemySpawner.StartCoroutine(enemySpawner.SpawnDelay(enemy, Random.Range(minSpawnDelay, maxSpawnDelay)));
        Invoke("StopEvent", duration);
    }

    protected override void StopEvent(){
        gameController.isEvent = false;
        isGoing = false;
        enemySpawner.StopAllCoroutines();
        if(GameObject.Find("Spaceship(Clone)"))
            Invoke("StopEvent", 1);
        else
        {
            enemySpawner.StartSpawningEnemys();
            GameObject.FindWithTag("Player").GetComponent<SpaceshipScript>().TakeHeal(20);
        }
    }
}
