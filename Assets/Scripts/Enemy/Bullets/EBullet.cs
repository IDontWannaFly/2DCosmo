using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    protected Camera mainCamera;
    protected GameControllerScript gameController;
    protected Transform target;

    protected abstract void BulletMove();
    protected virtual void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    protected virtual void Update()
    {
        BulletMove();
        if(gameController.isEvent == true)
        {
            Destroy(gameObject, 10);
        }
        else
        {
            if((transform.position.x <= mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).x)
                || (transform.position.x >= mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x)
                || (transform.position.y <= mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).y)
                || (transform.position.y >= mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y))
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0);
        }
    }
}
