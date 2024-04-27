using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ending : MonoBehaviour
{
    public globalEvent global;
    public VideoPlayer vid;
    public VideoClip good, bad;

    void Awake(){
        global=GetComponent<globalEvent>();
    }

    void Update(){
        if(global.goodEnding()){
            vid.clip=good;
        }else{
            vid.clip=bad;
        }
    }
}
