using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class verify : MonoBehaviour
{
   public bool isCek, formal, isTanya, isValid;
   public GameObject handler, tombolTanya, mark;
    
    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
    }
    void Update(){
        Tombtanya();
    }
    public void valid(){
        getMark("yes");
        isValid=true;
        handler.GetComponent<forScroll>().presentase+=25;
        isCek=true;
    }
    public void ragu(){
        isTanya=true;
        handler.GetComponent<forScroll>().upSroll();
    }
    public void tidakValid(){
        getMark("no");
        isValid=false;
        handler.GetComponent<forScroll>().presentase+=0;
        isCek=true;
    }
    void Tombtanya(){
        if(!formal){
            if(isTanya){
                tombolTanya.SetActive(false);
            }else{
                tombolTanya.SetActive(true);
            }
        }else{
            tombolTanya.SetActive(false);
        }

    }

    void getMark(string nama){
        Transform markChild=mark.transform.Find(nama);
        markChild.gameObject.SetActive(true);
    }
}
