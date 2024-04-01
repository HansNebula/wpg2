using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcTurn : MonoBehaviour
{
    public GameObject handler;
    public GameObject[] npcGameObject;

    void Update(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        turn();
    }

    void turn(){
        int n=handler.GetComponent<globalEvent>().global_id;
        for(int i=0;i<npcGameObject.Length;i++){
            if(i!=n){
                npcGameObject[i].SetActive(false);
            }else{
                npcGameObject[i].SetActive(true);
            }
        }
    }
}