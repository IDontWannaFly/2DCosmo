using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent : MonoBehaviour
{
    public float duration;
    public bool isGoing;
    public float minSpawnDelay;
    public float maxSpawnDelay; 
    public Enemy enemy;
    protected GameControllerScript gameController; 
    protected EnemySpawner enemySpawner; 
    public abstract void StartEvent(GameControllerScript gameController);
    protected abstract void StopEvent();
}
