using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneTemp : MonoBehaviour
{
    public float waktu=20f;
    public moveToScene move;

    void Start(){
        // hitungMundur();
        waktu=2f;
    }
    void Update(){
        if(waktu>0){
            waktu-=Time.deltaTime;
        }else{
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
