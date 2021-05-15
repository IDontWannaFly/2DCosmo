using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERocketShip : Enemy
{
    public float minLaunchDelay;
    public float maxLaunchDelay;
    private bool isRocketLaunched = false;
    public override bool IsAllowedToSpawn(){
        return true;
    }

    protected override void Start(){
        base.Start();
        if(gameController.GetLevel() < requiredLevel)
            Destroy(gameObject);
    }

    void Update(){
        EnemyMove();
        if((transform.position.y <= mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).y) && isRocketLaunched == false)
        {
            isRocketLaunched = true;
            Invoke("LaunchRocket", Random.Range(minLaunchDelay, maxLaunchDelay));            
        }
    }

    protected override void EnemyMove(){
        transform.Translate(Vector2.up * speed * Time.deltaTime * gameController.gameSpeed);
    }
    
    private void LaunchRocket(){
        ERocket rocket = transform.Find("Rocket").GetComponent<ERocket>();
        transform.DetachChildren();
        rocket.isLaunched = true;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Destroy(gameObject, 20);
    }
}
