using System.Collections;
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
        upSroll();
    }
    public void acc(){
        gameObject.GetComponent<count>().terhitung+=1;
        gameObject.GetComponent<count>().acc+=1;
        upSroll();
    }

    //Perdataan
    void StoreData(){
        switch(id){
            case 1 ://voga
                if(cp[0]){//kop
                    handler.GetComponent<globalEvent>().voga_.kop.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.kop.sudah=true;
                }
                if(cp[1]){//lb
                    handler.GetComponent<globalEvent>().voga_.lb.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.lb.sudah=true;
                }
                if(cp[2]){//dana
                    handler.GetComponent<globalEvent>().voga_.dana.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.dana.sudah=true;
                }
                if(cp[3]){//stempel
                    handler.GetComponent<globalEvent>().voga_.stempel.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().voga_.stempel.sudah=true;
                }
                break;
            case 2 ://waterion
                if(cp[0]){//kop
                    handler.GetComponent<globalEvent>().waterion_.kop.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.kop.sudah=true;
                }
                if(cp[1]){//lb
                    handler.GetComponent<globalEvent>().waterion_.lb.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.lb.sudah=true;
                }
                if(cp[2]){//dana
                    handler.GetComponent<globalEvent>().waterion_.dana.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.dana.sudah=true;
                }
                if(cp[3]){//stempel
                    handler.GetComponent<globalEvent>().waterion_.stempel.valid=handler.GetComponent<verify>().isValid;
                    handler.GetComponent<globalEvent>().waterion_.stempel.sudah=true;
                }
                break;
        }
        
    }
}