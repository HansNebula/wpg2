using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forScroll : MonoBehaviour
{
    public GameObject scroll, kop, latarBelakang, dana, instansi, decision, presObject, harga;
    public GameObject handler;
    public getNPC getnpc;
    public int id;
    public Sprite[] spProp, pres, hargaSp;
    public int presentase;
    bool isMuncul;
    public bool complete, openProp;

    public bool[] cp=new bool[4];

    //==========================================================================
    void Start(){
        isMuncul=false;
        scroll.SetActive(isMuncul);
    }
    void Update(){
        handler=gameObject;
        getnpc=handler.GetComponent<getNPC>();
        checkingComplete();
        changeProp();
        presentaseManager();
        id=PlayerPrefs.GetInt("global_id");
        StoreData();
        LoadData();
    }
    //==========================================================================

    void changeProp(){
        // int id_ncp=getnpc.id;
        scroll.GetComponent<SpriteRenderer>().sprite=spProp[handler.GetComponent<globalEvent>().global_id];
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
                handler.GetComponent<globalEvent>().voga_.presentase=presentase;
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
                handler.GetComponent<globalEvent>().waterion_.presentase=presentase;
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
                presentase=handler.GetComponent<globalEvent>().voga_.presentase=presentase;
                openProp=handler.GetComponent<globalEvent>().voga_.conv;
                if(handler.GetComponent<globalEvent>().voga_.kop.sudah){//kop
                    kop.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().voga_.kop.valid;
                    kop.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().voga_.lb.sudah){//lb
                    latarBelakang.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().voga_.lb.valid;
                    latarBelakang.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().voga_.dana.sudah){//dana
                    dana.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().voga_.dana.valid;
                    dana.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().voga_.stempel.sudah){//stempel
                    instansi.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().voga_.stempel.valid;
                    instansi.GetComponent<verify>().isCek=true;
                }
                break;
            case 2 ://waterion
                openProp=handler.GetComponent<globalEvent>().waterion_.conv;
                presentase=handler.GetComponent<globalEvent>().waterion_.presentase=presentase;
                if(handler.GetComponent<globalEvent>().waterion_.kop.sudah){//kop
                    kop.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().waterion_.kop.valid;
                    kop.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().waterion_.lb.sudah){//lb
                    latarBelakang.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().waterion_.lb.valid;
                    latarBelakang.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().waterion_.dana.sudah){//dana
                    dana.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().waterion_.dana.valid;
                    dana.GetComponent<verify>().isCek=true;
                }
                if(handler.GetComponent<globalEvent>().waterion_.stempel.sudah){//stempel
                    instansi.GetComponent<verify>().isValid = handler.GetComponent<globalEvent>().waterion_.stempel.valid;
                    instansi.GetComponent<verify>().isCek=true;
                }
                break;
        }
        
    }
    void presentaseManager(){
        presObject.GetComponent<SpriteRenderer>().sprite=pres[presentase/25];
        harga.GetComponent<SpriteRenderer>().sprite=hargaSp[handler.GetComponent<globalEvent>().global_id];
    }
}