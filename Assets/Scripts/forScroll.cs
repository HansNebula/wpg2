﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forScroll : MonoBehaviour
{
    public GameObject scroll, kop, latarBelakang, dana, instansi, decision;
    public GameObject handler;
    public getNPC getnpc;
    public int id;
    public Sprite[] spProp;
    public float presentase;
    bool isMuncul;
    public bool complete;

    bool[] cp=new bool[4];

    void Start(){
        isMuncul=false;
    }
    void Update(){
        scroll.SetActive(isMuncul);
        checkingComplete();
        changeProp();
        getnpc=GetComponent<getNPC>();
        handler=GameObject.FindGameObjectWithTag("GameController");
        id=PlayerPrefs.GetInt("global_id");
        StoreData();
    }

    void changeProp(){
        int id_ncp=getnpc.id;
        scroll.GetComponent<SpriteRenderer>().sprite=spProp[id_ncp];
    }

    
    void checkingComplete(){
        cp[0]=kop.GetComponent<verify>().isCek;
        cp[1]=latarBelakang.GetComponent<verify>().isCek;
        cp[2]=dana.GetComponent<verify>().isCek;
        cp[3]=instansi.GetComponent<verify>().isCek;
        decision.SetActive(complete);
        for(int i=0;i<cp.Length;i++){
            if(!cp[i]){
                complete=false;
                break;
            }else{
                complete=true;
            }
        }
    }
    public void upSroll(){
        isMuncul=!isMuncul;
    }
    public void tolak(){
        gameObject.GetComponent<count>().tolak+=1;
        gameObject.GetComponent<count>().terhitung+=1;
        handler.GetComponent<globalEvent>().voga_.check=true;
        if(id==1){
            handler.GetComponent<globalEvent>().voga_.diterima=false;
        }else if(id==2){
            handler.GetComponent<globalEvent>().waterion_.diterima=false;
        }
        upSroll();
    }
    public void acc(){
        gameObject.GetComponent<count>().terhitung+=1;
        gameObject.GetComponent<count>().acc+=1;

        handler.GetComponent<globalEvent>().voga_.check=true;
        if(id==1){
            handler.GetComponent<globalEvent>().voga_.diterima=true;
        }else if(id==2){
            handler.GetComponent<globalEvent>().waterion_.diterima=true;
        }
        upSroll();
    }

    //Perdataan
    void StoreData(){
        switch(id){
            case 1 ://voga
                if(kop.GetComponent<verify>().isCek){//kop
                    handler.GetComponent<globalEvent>().voga_.kop.valid=kop.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.kop.sudah=true;
                }
                if(latarBelakang.GetComponent<verify>().isCek){//lb
                    handler.GetComponent<globalEvent>().voga_.lb.valid=latarBelakang.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.lb.sudah=true;
                }
                if(dana.GetComponent<verify>().isCek){//dana
                    handler.GetComponent<globalEvent>().voga_.dana.valid=dana.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.dana.sudah=true;
                }
                if(instansi.GetComponent<verify>().isCek){//stempel
                    handler.GetComponent<globalEvent>().voga_.stempel.valid=instansi.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.stempel.sudah=true;
                }
                break;
            case 2 ://waterion
                if(kop.GetComponent<verify>().isCek){//kop
                    handler.GetComponent<globalEvent>().waterion_.kop.valid=kop.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.kop.sudah=true;
                }
                if(latarBelakang.GetComponent<verify>().isCek){//lb
                    handler.GetComponent<globalEvent>().waterion_.lb.valid=latarBelakang.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.lb.sudah=true;
                }
                if(dana.GetComponent<verify>().isCek){//dana
                    handler.GetComponent<globalEvent>().waterion_.dana.valid=dana.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.dana.sudah=true;
                }
                if(instansi.GetComponent<verify>().isCek){//stempel
                    handler.GetComponent<globalEvent>().waterion_.stempel.valid=instansi.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.stempel.sudah=true;
                }
                break;
        }
        
    }

    void LoadData(){
        switch(id){
            case 1 ://voga
                if(handler.GetComponent<globalEvent>().voga_.kop.sudah){//kop
                    handler.GetComponent<globalEvent>().voga_.kop.valid=kop.GetComponent<verify>().isValid;
                    kop.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().voga_.lb.sudah){//lb
                    handler.GetComponent<globalEvent>().voga_.lb.valid=latarBelakang.GetComponent<verify>().isValid;
                    latarBelakang.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().voga_.dana.sudah){//dana
                    handler.GetComponent<globalEvent>().voga_.dana.valid=dana.GetComponent<verify>().isValid;
                    dana.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().voga_.stempel.sudah){//stempel
                    handler.GetComponent<globalEvent>().voga_.stempel.valid=instansi.GetComponent<verify>().isValid;
                    instansi.GetComponent<verify>().isCek=true;
                }
                break;
            case 2 ://waterion
                if(handler.GetComponent<globalEvent>().waterion_.kop.sudah){//kop
                    handler.GetComponent<globalEvent>().waterion_.kop.valid=kop.GetComponent<verify>().isValid;
                    kop.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().waterion_.lb.sudah){//lb
                    handler.GetComponent<globalEvent>().waterion_.lb.valid=latarBelakang.GetComponent<verify>().isValid;
                    latarBelakang.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().waterion_.dana.sudah){//dana
                    handler.GetComponent<globalEvent>().waterion_.dana.valid=dana.GetComponent<verify>().isValid;
                    dana.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().waterion_.stempel.sudah){//stempel
                    handler.GetComponent<globalEvent>().waterion_.stempel.valid=instansi.GetComponent<verify>().isValid;
                    instansi.GetComponent<verify>().isCek=true;
                }
                break;
        }
        
    }
}