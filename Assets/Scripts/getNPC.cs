using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getNPC : MonoBehaviour
{
   public GameObject npc;
   void Update(){
    npc=GameObject.FindGameObjectWithTag("npc");
   }
    public void nextDialog(){
        int id=npc.GetComponent<npcID>().id;
        if(id==1){
            //voga
            npc.GetComponent<dialogVoga>().nextDialog();
        }
    }

    public void switchToCase(int value){
        int id=npc.GetComponent<npcID>().id;
        if(id==1){
            //voga
            npc.GetComponent<dialogVoga>().switchToCase(value);
        }
    }
}
