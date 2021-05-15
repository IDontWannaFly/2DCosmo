using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERocket : EBullet
{
    public bool isLaunched;
    private bool isTargetReached;
    private Transform player;
    protected override void Start(){
        base.Start();
        target = transform.Find("RocketTarget");
        player = GameObject.FindWithTag("PGhost").transform;
        isLaunched = false;
    }

    protected override void Update(){
        if(isLaunched == true)
            BulletMove();
        if((Vector2.Distance(transform.position, player.position) <= 0.5f) && (isTargetReached == false))
        {
            isTargetReached = true;
        }
    }

    protected override void BulletMove(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime * gameController.gameSpeed);
        if(isTargetReached == false)
        {
            Vector3 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * Time.deltaTime * gameController.gameSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player")
        {
            if(isLaunched == false)
            {
                transform.parent.GetComponent<Enemy>().DestroyEnemy();
            }
            else
            {
                Destroy(gameObject, 0);
            }
        }
    }
}
