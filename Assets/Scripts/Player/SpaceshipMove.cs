using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMove : MonoBehaviour
{
    public float speed;
    private Camera mainCamera;
    private Animator pAnimator;
    // Start is called before the first frame update
    void Start()
    {
        pAnimator = gameObject.GetComponent<Animator>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= (mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + (transform.localScale.x / 2)))
            if(Input.GetKey(KeyCode.A))
	            {
                    pAnimator.SetInteger("Action", 1);
			        transform.position += new Vector3(-(Time.deltaTime * speed), 0);
		        }
        if(transform.position.x <= (mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - (transform.localScale.x / 2)))
            if(Input.GetKey(KeyCode.D))
	            {
                    pAnimator.SetInteger("Action", 2);
        		    transform.position += new Vector3((Time.deltaTime * speed), 0);
		        }
        if((Input.GetKey(KeyCode.A) == false) && (Input.GetKey(KeyCode.D) == false))  
            pAnimator.SetInteger("Action", 0);
        if(transform.position.y <= (mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - (transform.localScale.y / 2)))
            if(Input.GetKey(KeyCode.W))      
                transform.position += new Vector3(0, Time.deltaTime * speed, 0);
        if(transform.position.y >= (mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + (transform.localScale.y / 2)))
            if(Input.GetKey(KeyCode.S))
                transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
    }
}
