using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseTele : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject dialogBox, field, pauseObj;
    public bool isPause;

    void Update(){
        for(int i = 0;i<buttons.Length;i++){
            if(isPause){
                dialogBox.SetActive(false);
                field.SetActive(false);
                buttons[i].SetActive(false);
            }else{
                buttons[i].SetActive(true);
                field.SetActive(true);
            }
        }
    }

    public void pausing(bool v){
        isPause=v;
    }
}
