using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	public GameObject player;
    private GameControllerScript gameController;
    private bool keepDistance = true;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }

    void Update(){
        if(player == null)
            return;
        if(keepDistance == true)
            if(Vector2.Distance(gameObject.transform.position, player.transform.position) >= player.transform.lossyScale.x / 2)
                keepDistance = false;
        if(keepDistance == false)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                player.transform.position, 
                Time.deltaTime 
                    * (player.GetComponent<SpaceshipMove>().speed - 1.5f) 
                    * gameController.gameSpeed
                    * (Vector3.Distance(transform.position, player.transform.position) * 2/* * 0.04f*/)
                );
            if(Vector2.Distance(gameObject.transform.position, player.transform.position) == 0)
                keepDistance = true;
        }
    }
}
