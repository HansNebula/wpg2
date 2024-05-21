using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getNPC : MonoBehaviour
{
   public GameObject npc, handler;
   public int id;
   void Update(){
    handler=GameObject.FindGameObjectWithTag("GameController");
    npc=GameObject.FindGameObjectWithTag("npc");
    id=npc.GetComponent<npcID>().id;
    // handler.GetComponent<globalEvent>().currentId=id;
   }
    public void nextDialog(){
        id=npc.GetComponent<npcID>().id;
        if(id==1){
            //voga
            npc.GetComponent<dialogVoga>().nextDialog();
        }else if(id==2){
            //waterion
            npc.GetComponent<dialogWater>().nextDialog();
        }else if(id==0){
            //waterion
            npc.GetComponent<dialogMino>().nextDialog();
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
        }else if(id==0){//mino
            npc.GetComponent<dialogMino>().switchToCase(value);
        }
    }
}
