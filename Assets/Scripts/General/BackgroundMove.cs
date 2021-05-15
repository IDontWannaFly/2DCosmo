using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private float speed;
    private Camera mainCamera;
    private LevelBuilder levelBuild;
    private GameControllerScript gameController;
    private Vector2 startPosition;

    void Start(){
        startPosition = transform.position;
        levelBuild = GameObject.Find("GameController").GetComponent<LevelBuilder>();
        mainCamera = levelBuild.mainCamera;
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        speed = gameController.objectsSpeed;        
    }

    void Update(){
        if(transform.position.y >= mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).y - ((levelBuild.heigth * levelBuild.rowsCount) / 4))
        {
            transform.position += new Vector3(transform.position.x, -(Time.deltaTime * speed * gameController.gameSpeed), 0);
        }
        else
        {
            transform.position = startPosition /*+ new Vector2(0, Time.deltaTime * speed * gameController.gameSpeed)*/;
        }
    }
}
