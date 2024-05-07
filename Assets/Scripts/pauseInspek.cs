using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseInspek : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject prop, pauseObj, dialogBox;
    public dialogVoga voga;
    public dialogWater water;
    public dialogMino mino;
    public bool isPause;

    void Start(){
        PlayerPrefs.SetInt("visited", 1);
    }

    void Update(){
        for(int i = 0;i<buttons.Length;i++){
            if(isPause){
                prop.SetActive(false);
                buttons[i].SetActive(false);
                dialogBox.SetActive(false);
            }else{
                buttons[i].SetActive(true);
            }
        }
    }

    public void pausing(bool v){
        isPause=v;
    }

    public void restartConv(){
        if(PlayerPrefs.GetInt("global_id")==1 && PlayerPrefs.GetInt("voga_conv")==0){
            voga.n=1;
        }else if(PlayerPrefs.GetInt("global_id")==2 && PlayerPrefs.GetInt("water_conv")==0){
            water.n=1;
        }else if(PlayerPrefs.GetInt("global_id")==0 && PlayerPrefs.GetInt("mino_conv")==0){
            water.n=1;
        }
    }
}
