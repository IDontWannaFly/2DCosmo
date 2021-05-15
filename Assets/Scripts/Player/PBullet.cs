using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float speed;
    public float damage;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * speed, 0);   
        if(transform.position.y + (transform.lossyScale.y / 2) >= mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y)     
            Destroy(gameObject, 0.5f);
    }
}
