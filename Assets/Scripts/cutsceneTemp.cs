using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneTemp : MonoBehaviour
{
    public float waktu=20f;
    public moveToScene move;
    public string dest;
    int id;
    void Start(){
        id=PlayerPrefs.GetInt("global_id");
        waktu=3f;
        // GetComponent<globalEvent>().LoadData();
        // hitungMundur();
    }
    void Update(){
        if(waktu>0){
            waktu-=Time.deltaTime;
        }else{
            // GetComponent<globalEvent>().StoreData();
            PlayerPrefs.SetInt("global_id", id+1);
            move.pindah(dest);
        }

    }

    void hitungMundur(){
        while(waktu!=0){
            waktu-=Time.deltaTime;
        }
        move.pindah(dest);
    }
}
