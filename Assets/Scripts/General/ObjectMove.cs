using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float speed;
    private Camera mainCamera;
    private GameControllerScript gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        speed = gameController.objectsSpeed;        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(0, Time.deltaTime * speed * gameController.gameSpeed, 0);
        if(transform.position.y < mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y)
            Destroy(gameObject, 0.5f);
    }
}
