using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveSet : MonoBehaviour
{
    protected Camera mainCamera;
    protected GameControllerScript gameController;

    void Start(){
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }

    protected abstract void MoveToPosition();
    public abstract void Play();

    public abstract void EndPhase();

    public abstract void BeginPhase();
}
