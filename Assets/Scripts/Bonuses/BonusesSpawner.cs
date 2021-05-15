using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesSpawner : MonoBehaviour
{
    public GameObject[] bonuses;
    public float minBonusSpawnDelay;
    public float maxBonusSpawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var bonus in bonuses)
        {
            StartCoroutine(SpawnDelay(bonus));
        }
    }

    IEnumerator SpawnDelay(GameObject bonus){
        yield return new WaitForSeconds(Random.Range(minBonusSpawnDelay, maxBonusSpawnDelay));
        SpawnBonus(bonus);
    }

    void SpawnBonus(GameObject bonus){
        GameObject spawnedBonus = Instantiate(bonus, transform.position, Quaternion.identity);
        StartCoroutine(SpawnDelay(bonus));
    }

}
