using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public GameObject[] clouds;
    void Awake(){
        gameObject.GetComponent<globalEvent>().setGlobalId();
        // ResetGlobal();
        Debug.Log("reset");
    }

    void Update(){
        for(int i = 0; i<clouds.Length;i++){
            Vector3 currentPosition = clouds[i].transform.position;
            float newX = currentPosition.x - 0.005f;
            Vector3 newPosition = new Vector3(newX, currentPosition.y, currentPosition.z);
            clouds[i].transform.position = newPosition;
            if(clouds[i].transform.position.x<-40f){
                currentPosition.x = 35f;
                clouds[i].transform.position = currentPosition;
            }
        }
    }

    void ResetGlobal(){
        PlayerPrefs.SetInt("visited", 0);
        PlayerPrefs.SetInt("global_id", 0);
    }
}
