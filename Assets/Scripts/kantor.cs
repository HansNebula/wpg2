using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kantor : MonoBehaviour
{
    public GameObject scroll;
    public GameObject char_;
    public GameObject blok;
    void Update(){
        var global=gameObject.GetComponent<globalEvent>();
        visible();
        if(global.visited==false && global.isTutorial()){
            blok.SetActive(true);
        }else{
            blok.SetActive(false);
        }
    }
    void visible(){
        var global=gameObject.GetComponent<globalEvent>();
        scroll.SetActive(global.visited);
        char_.SetActive(true);
        if(global.global_id==1){
            if(PlayerPrefs.GetInt("voga_conv")==1){
                scroll.SetActive(true);
            }else if(PlayerPrefs.GetInt("voga_conv")==0){
                scroll.SetActive(false);
            }
        }else if(global.global_id==2){
            if(PlayerPrefs.GetInt("water_conv")==1){
                scroll.SetActive(true);
            }else if(PlayerPrefs.GetInt("water_conv")==0){
                scroll.SetActive(false);
            }
        }else if(global.global_id==0){
            if(PlayerPrefs.GetInt("mino_conv")==1){
                scroll.SetActive(true);
            }else if(PlayerPrefs.GetInt("mino_conv")==0){
                scroll.SetActive(false);
            }
        }
    }
    
}
