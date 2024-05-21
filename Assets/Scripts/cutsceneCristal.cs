using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class cutsceneCristal : MonoBehaviour
{
    public globalEvent global;
    public VideoPlayer vid;
    public VideoClip tutorClip, vogaClip, waterClip;

    void Awake(){
        global=GetComponent<globalEvent>();
    }

    void Update(){
        if(global.global_id==0){
            vid.clip=tutorClip;
            PlayerPrefs.SetInt("tahap", 7);
        }else if(global.global_id==1){
            vid.clip=vogaClip;
        }else if(global.global_id==2){
            vid.clip=waterClip;
        }
    }
}
