using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpaceship : Enemy
{
    public GameObject bulletPrefab;
    public float fireRate;
    private GameObject target;
    private Transform spaceshipGun;
    private float distanceMultipler;
    private bool isInPosition;
    private int moveSide;

    void Update(){
        EnemyMove();
    }

    protected override void Start(){
        base.Start();
        target = GameObject.FindWithTag("PGhost");
        distanceMultipler = Random.Range(3f, 5f);
        spaceshipGun = transform.Find("SpaceshipGun").transform;
        isInPosition = false;
        if(isEvent == true)
            health *= 2;
        if(Random.Range(0, 1) == 0)
            moveSide = 1;
        else
            moveSide = -1;
        Invoke("Shoot", fireRate / gameController.gameSpeed);
    }

    protected override void EnemyMove(){
        if(isEvent == false)
        {
            if(transform.position.y != new Vector2(transform.position.x, mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - transform.lossyScale.y).y)
            {
                MoveToPosition();
            }
            else
            {
                FollowTarget();
            }
        }
        else
        {
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            if(Vector2.Distance(transform.position, target.transform.position) > (transform.lossyScale.x * 6))
                isInPosition = false;
            if(isInPosition == false)
            {
                if(Vector2.Distance(transform.position, target.transform.position) > (transform.lossyScale.x * distanceMultipler))
                {
                    MoveToPosition();
                }
                else
                {
                    isInPosition = true;                    
                    FollowTarget();
                }
            }
            else
            {
                FollowTarget();
            }
        }
    }

    public override bool IsAllowedToSpawn(){
        if(GameObject.Find("GameController").GetComponent<GameControllerScript>().isEvent == true)
            return true;
        if(GameObject.Find("Spaceship(Clone)"))
            return false;
        return true;
    }    

    private void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, spaceshipGun.position, transform.rotation);
        Invoke("Shoot", fireRate / gameController.gameSpeed);
    }

    private void MoveToPosition(){
        if(isEvent == false)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                new Vector2(transform.position.x, mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - transform.lossyScale.y), 
                speed * Time.deltaTime * gameController.gameSpeed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                target.transform.position, 
                Time.deltaTime * speed * gameController.gameSpeed);
        }
    }

    private void FollowTarget(){
        if(isEvent == false)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                new Vector2(target.transform.position.x, mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - transform.lossyScale.y),
                speed * Time.deltaTime * gameController.gameSpeed);
        }
        else
        {
            transform.Translate(new Vector2(moveSide * speed * Time.deltaTime * gameController.gameSpeed, 0));
        }
    }
}
