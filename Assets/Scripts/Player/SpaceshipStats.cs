using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipStats : MonoBehaviour
{
	public float health;
	public int bulletsCount;
	public int shootingType;
	public string[] buffs;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bonus")
        {
            //if(col.gameObject.name == "2xPower")
        }
    }
}
