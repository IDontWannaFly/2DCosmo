using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public List<GameObject> bulletPrefabs;
    public GameObject currentBullet;
    public float fireRate;
    public int bulletsCount;
	public int shootingType;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", 0);
    }

    void Shoot(){
        for(int i = 0; i < bulletsCount; i++){
            GameObject bullet = Instantiate(currentBullet, new Vector3(transform.position.x - (transform.lossyScale.x / 2) + ((transform.lossyScale.x / (bulletsCount != 1 ? bulletsCount - 1 : 2)) * (bulletsCount != 1 ? i : i + 1)), transform.position.y + transform.lossyScale.y / 2, 0), transform.rotation);
        }
        Invoke("Shoot", fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
