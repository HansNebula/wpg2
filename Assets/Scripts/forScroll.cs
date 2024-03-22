using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forScroll : MonoBehaviour
{
    public GameObject scroll, kop, latarBelakang, dana, instansi, decision;
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
        upSroll();
    }
    public void acc(){
        gameObject.GetComponent<count>().acc+=1;
        upSroll();
    }
}
