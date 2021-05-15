using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETurret : Enemy
{
    private GameObject target;
    private Transform barrel;
    public GameObject bulletPrefab;
    public float fireRate;

    protected override void Start(){
        base.Start();
        barrel = transform.Find("TurretGun").transform.Find("TurretGunBarrel").transform;
        target = GameObject.FindWithTag("Player");
        Invoke("Shoot", fireRate / gameController.gameSpeed);
    }

    void Update(){
        EnemyMove();
    }

    public override bool IsAllowedToSpawn(){
        return false;
    }

    protected override void EnemyMove(){
        /*Quaternion rotation = Quaternion.LookRotation
             (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
         transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);*/
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        Invoke("Shoot", fireRate / gameController.gameSpeed);
    }
}
