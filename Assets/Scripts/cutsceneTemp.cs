using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneTemp : MonoBehaviour
{
    public float waktu=20f;
    public moveToScene move;
    int id;
    void Start(){
        id=PlayerPrefs.GetInt("global_id");
        waktu=2f;
        // hitungMundur();
    }
    void Update(){
        if(waktu>0){
            waktu-=Time.deltaTime;
        }else{
            PlayerPrefs.SetInt("global_id", id+1);
            move.pindah("SceneMeja");
        }

    }

    void hitungMundur(){
        while(waktu!=0){
            waktu-=Time.deltaTime;
        }
        move.pindah("SceneMeja");
    }
}
