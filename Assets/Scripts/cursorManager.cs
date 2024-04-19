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
        GameObject cursorMagic = handler.GetComponent<globalEvent>().pointerWand;
        cursorMagic.SetActive(true);
    }
}
