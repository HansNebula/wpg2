using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject prop, pauseObj;
    public bool isPause;

    void Update(){
        for(int i = 0;i<buttons.Length;i++){
            if(isPause){
                prop.SetActive(false);
                buttons[i].SetActive(false);
            }else{
                buttons[i].SetActive(true);
            }
        }
    }

    public void pausing(bool v){
        isPause=v;
    }
}
