using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GameObject lvlBackground;
    public GameObject empty;
    public float width;
    public float heigth;
    public Camera mainCamera;
    public int rowsCount;
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        GameObject backgroundsStack = Instantiate(empty, new Vector2(0, 0), Quaternion.identity);
        Vector2 startPoint = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)) + new Vector3(width / 2, heigth / 2, 0);
        rowsCount = Mathf.RoundToInt(Mathf.Ceil((mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y * 2) / heigth) * 2);
        for(int i = 0; i < Mathf.Ceil((mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x * 2) / width); i++)
        {
            for(int j = 0; j < Mathf.Ceil((mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y * 2) / heigth) * 2; j++)
            {
                
                Vector3 pos = new Vector3(
                    startPoint.x + (width * i), 
                    startPoint.y + (heigth * j),
                    0.1f
                );
                GameObject background = Instantiate(lvlBackground, pos , Quaternion.identity);
                background.transform.SetParent(backgroundsStack.transform);
            }
        }
    }
}
