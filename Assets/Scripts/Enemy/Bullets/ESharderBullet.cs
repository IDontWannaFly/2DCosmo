using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESharderBullet : EBullet
{
    public GameObject shardPrefab;
    public float minSpreadingDelay;
    public float maxSpreadingDelay;
    private int bulletCount;
    protected override void Start(){
        base.Start();
        if(bulletCount == 0)
        {
            if(gameController.isEvent == false)
                bulletCount = Random.Range(4, 8);
            else
                bulletCount = Random.Range(9, 16);
        }
        damage = bulletCount * 5;
        Invoke("Spreading", Random.Range(minSpreadingDelay, maxSpreadingDelay));
    }

    protected override void BulletMove(){
        transform.Translate(new Vector2(0, (speed * Time.deltaTime * gameController.gameSpeed)));
    }

    private void Spreading(){        
        if(bulletCount <= 8)
        {
            float rotationStep = 360 / bulletCount;
            for(int i = 1; i <= bulletCount; i++)
            {
                GameObject shard = Instantiate(shardPrefab, transform.position, Quaternion.Euler(0, 0, transform.rotation.z + (rotationStep * i)));
            }
        }
        else
        {
            int rotationStep = 180;
            int shardsDirection = Random.Range(0, 1) * 90;
            for(int i = 1; i <= 2; i++)
            {
                GameObject shard = Instantiate(gameObject, transform.position, Quaternion.Euler(0, 0, transform.rotation.z + (rotationStep * i) + shardsDirection));
                if(i == 1)
                {
                    shard.GetComponent<ESharderBullet>().bulletCount = (int)Mathf.Floor(bulletCount / 2);
                    bulletCount -= (int)Mathf.Floor(bulletCount / 2);
                }
                else
                {
                    shard.GetComponent<ESharderBullet>().bulletCount = bulletCount;
                }
            }
        }
        Destroy(gameObject, 0);
    }
}
