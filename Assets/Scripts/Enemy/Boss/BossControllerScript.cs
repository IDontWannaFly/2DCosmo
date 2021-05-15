using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControllerScript : MonoBehaviour
{
    public List<BCCabin> cabinsScripts;
    public List<MoveSet> moveSets;
    private MoveSet currentMoveSet;
    private bool isStageEnd;
    private int phase = 1;

    public void CabinDestroyed(GameObject cabin){
        cabin.GetComponent<SpriteRenderer>().sprite = cabin.GetComponent<BCCabin>().phasesSprite[phase];
        /*GameObject protection = Instantiate(cabin.GetComponent<BCCabin>().protectionPrefab, cabin.transform.position, cabin.transform.rotation);
        protection.transform.SetParent(cabin.transform);
        protection.transform.localPosition = new Vector3(0, 0, 0);*/
        if(cabinsScripts.Exists(c => c.IsDestroyed() == false) == false)
        {
            EndStage();
        }
    }

    void EndStage(){
        isStageEnd = true;
    }

    void Update(){
        if(isStageEnd == false)
            currentMoveSet.Play();
        else
            currentMoveSet.EndPhase();
    }

}
