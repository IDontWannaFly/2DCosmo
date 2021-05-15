using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAsteroid : Enemy
{
    public GameObject turretPrefab;
    public float minStatsMultiple;
    public float maxStatsMultiple;

    protected override void EnemyMove(){
            gameObject.transform.position -= new Vector3(0, Time.deltaTime * speed * gameController.gameSpeed, 0);
    }
    public override bool IsAllowedToSpawn(){
        return true;
    }

    protected override void Start(){
        base.Start();
        float statsMultiple = Random.Range(minStatsMultiple, maxStatsMultiple);
        health *= statsMultiple;
        transform.localScale *= statsMultiple;
        expForKill *= statsMultiple;
        if((transform.localScale.x >= 0.8f) && (transform.localScale.y >= 0.8f) && (gameController.GetLevel() >= 4))
        {
            GameObject turret = Instantiate(turretPrefab, transform.position, transform.rotation);
            turret.transform.localScale = gameObject.transform.localScale / 2;
            turret.transform.SetParent(gameObject.transform);
            turret.transform.localPosition += new Vector3(0, 0, -0.5f);
        }
    }

    void Update(){
        EnemyMove();
        if(transform.position.y < mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y)
            Destroy(gameObject, 0.5f);
    }

    protected override void OnTriggerEnter2D(Collider2D col){
        base.OnTriggerEnter2D(col);
        if(col.tag == "Player")
        {
            health -= health;
        }
    }
}
