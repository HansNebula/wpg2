using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getNPC : MonoBehaviour
{
   public GameObject npc;
   public int id;
   void Update(){
    npc=GameObject.FindGameObjectWithTag("npc");
    id=npc.GetComponent<npcID>().id;
   }
    public void nextDialog(){
        id=npc.GetComponent<npcID>().id;
        if(id==1){
            //voga
            npc.GetComponent<dialogVoga>().nextDialog();
        }else if(id==2){
            //waterion
            npc.GetComponent<dialogWater>().nextDialog();
        }
    }

    public void switchToCase(int value){
        int id=npc.GetComponent<npcID>().id;
        if(id==1){
            //voga
            npc.GetComponent<dialogVoga>().switchToCase(value);
        }else if(id==2){
            //waterion
            npc.GetComponent<dialogWater>().switchToCase(value);
        }
    }
}
