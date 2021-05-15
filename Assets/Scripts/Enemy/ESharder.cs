using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESharder : Enemy
{
    public GameObject bulletPrefab;
    public float fireRate;
    private int moveWay = 1;

    protected override void Start(){
        base.Start();
        if(gameController.GetLevel() < requiredLevel)
            Destroy(gameObject, 0);
        Invoke("Shoot", fireRate / gameController.gameSpeed);
    }

    void Update(){        
        EnemyMove();
    }
    public override bool IsAllowedToSpawn(){
        if(GameObject.Find("GameController").GetComponent<GameControllerScript>().isEvent == true)
            return true;
        if(GameObject.Find("Sharder(Clone)"))
            return false;
        return true;
    }

    protected override void EnemyMove(){
        if(transform.position.y != new Vector2(transform.position.x, mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - transform.lossyScale.y).y)
        {
            MoveToPosition();
        }
        else
        {
            MoveToSide();
        }
    }

    private void MoveToPosition(){
        transform.position = Vector2.MoveTowards(
            transform.position, 
            new Vector2(0, mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - transform.lossyScale.y), 
            speed * Time.deltaTime * gameController.gameSpeed);
    }

    private void MoveToSide(){
        transform.Translate(new Vector2(moveWay * (speed * Time.deltaTime * gameController.gameSpeed), 0));
        if((transform.position.x - (transform.lossyScale.x / 2) <= mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).x) 
            || (transform.position.x + (transform.lossyScale.x / 2) >= mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x))
            moveWay *= -1;
    }

    private void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position - new Vector3(0, transform.lossyScale.y / 2, 0), transform.rotation);
        Invoke("Shoot", fireRate / gameController.gameSpeed);
    }
}
