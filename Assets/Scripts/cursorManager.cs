using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    public GameObject handler;
    
    void Update(){
        handler=GameObject.FindGameObjectWithTag("GameController");
    }

    void OnMouseOver(){
        handler.GetComponent<globalEvent>().isClickable=true;
    }

    void OnMouseExit(){
        handler.GetComponent<globalEvent>().isClickable=false;
    }
}
