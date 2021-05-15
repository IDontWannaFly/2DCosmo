using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDefaultBullet : EBullet
{
    protected override void Start(){
        base.Start();
        target = transform.Find("target");
    }

    protected override void BulletMove(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed * gameController.gameSpeed);
    }
}
