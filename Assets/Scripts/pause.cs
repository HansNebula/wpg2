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
                if(PlayerPrefs.GetInt("global_id")==1){
                    if(PlayerPrefs.GetInt("voga_conv")==0){
                        if(buttons[i].transform.name=="INSPEKTOR_5"){
                            buttons[i].SetActive(false);
                        }else{
                            buttons[i].SetActive(true);
                        }
                    }
                }else if(PlayerPrefs.GetInt("global_id")==2){
                    if(PlayerPrefs.GetInt("water_conv")==0){
                        if(buttons[i].transform.name=="INSPEKTOR_5"){
                            buttons[i].SetActive(false);
                        }else{
                            buttons[i].SetActive(true);
                        }
                    }
                }else if(PlayerPrefs.GetInt("global_id")==0){
                    if(PlayerPrefs.GetInt("mino_conv")==0){
                        if(buttons[i].transform.name=="INSPEKTOR_5"){
                            buttons[i].SetActive(false);
                        }else{
                            buttons[i].SetActive(true);
                        }
                    }
                }
            }
        }
    }

    public void pausing(bool v){
        isPause=v;
    }
}
