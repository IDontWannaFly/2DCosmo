using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public List<Enemy> enemys;	
	private float gameSpeed;
	private Camera mainCamera;
	private GameControllerScript gameController;

	void Start(){
		gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
		mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		StartSpawningEnemys();
	}

	void Update(){
		gameObject.transform.localScale = new Vector3(mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x * 2, 1, 1);
	}

	public void StartSpawningEnemys(){
		foreach(var enemy in enemys)
			StartCoroutine(SpawnDelay(enemy, Random.Range(enemy.minSpawnDelay, enemy.maxSpawnDelay)));
	}

	public IEnumerator SpawnDelay(Enemy enemy, float delay){
		yield return new WaitForSeconds(delay / (gameController.gameSpeed == 0 ? 1 : gameController.gameSpeed));
		SpawnEnemy(enemy, delay);
	}

	void SpawnEnemy(Enemy enemy, float delay){
		if(enemy.IsAllowedToSpawn() == true)
		{
			GameObject spawnedEnemy = Instantiate(enemy.enemyPrefab, new Vector3(Random.Range(transform.position.x - transform.lossyScale.x / 2, transform.position.x + transform.lossyScale.x / 2), transform.position.y, transform.position.z), transform.rotation);
		}
		StartCoroutine(SpawnDelay(enemy, delay));
	}
}
